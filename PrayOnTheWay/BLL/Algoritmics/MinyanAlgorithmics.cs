using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Algoritmics    
{
    public class MinyanAlgorithmics
    {
        MinyanBLL minyanBll = new MinyanBLL();
        AsksToMinyanBLL asksToMinyanBLL = new AsksToMinyanBLL();
        SafePointOnTheWayBLL safePointOnTheWayBLL = new SafePointOnTheWayBLL();
        TimeAlgorithmics timeAlgorithmics = new TimeAlgorithmics();
        LocationAlgorithmics locationAlgorithmics = new LocationAlgorithmics();

        public List<MinyanDTO> SearchMatchMinyan(LocationPoint driverLocation)
        {
            List<MinyanDTO> matchMinyan = new List<MinyanDTO>();
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach (var m in minyans)
            {
                if(IsMinyanActive(m.IDMinyan))
                {
                    if(locationAlgorithmics.RouteDistanceInSecondOnModeDrive(driverLocation, locationAlgorithmics.GetLocationByIDMinyan(m.IDLocationMinyan))<LocationAlgorithmics.R)
                    {
                        matchMinyan.Add(m);
                    }
                }
            }
            
            return matchMinyan;
        }
        
        public void AddPrayerToMinyan(long idMinyan)
        {
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach(MinyanDTO min in minyans)
            {
                if(min.IDMinyan == idMinyan)
                {
                    min.NumOfPeopleInMinyan++;
                    minyanBll.UpdateMinyan(min);
                    break;
                }
            }   
        }
        public void RemovePrayerFromMinyan(long idMinyan)
        {
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach (MinyanDTO min in minyans)
            {
                if (min.IDMinyan == idMinyan)
                {

                    min.NumOfPeopleInMinyan--;
                    minyanBll.UpdateMinyan(min);
                    break;
                }
            }
        }
        public int NumOfPeopleInMinyan(long idMinyan)
        {
            //the func return amount of people in the minyan if empty return -1
            int numOfPeopleInMinyan = -1;
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach (MinyanDTO min in minyans)
            {
                if (min.IDMinyan == idMinyan)
                {
                    numOfPeopleInMinyan = min.NumOfPeopleInMinyan;
                    break;
                }
            }
            return numOfPeopleInMinyan;
        }
        public bool  IsMinyanActive(long idMinyan)
        {
            return NumOfPeopleInMinyan(idMinyan) > 0;
        }

        public int MinyansInPercent()
        {
            return 1;
        }
        public AsksToMinyanDTO ShowAndChooseMinyans(List<MinyanDTO> minyans)
        {
            return new AsksToMinyanDTO();
        }
        public void SavingChoose(int idMinyan)
        {

        }
        public AsksToMinyanDTO CreateMinyan(LocationPoint driverLocation, long idAskMinyan)
        {
            List<OptionalLocation> optionals = locationAlgorithmics.FindOptionalLocations(driverLocation);
            int c = optionals.Count;
            switch (c)
            {
                case 0:return new AsksToMinyanDTO();
                    
                default:
                safePointOnTheWayBLL.AddSafePointOnTheWay(
                    new SafePointOnTheWayDTO 
                    {
                        Lat = optionals[0].Point.Lat,
                        Lng = optionals[0].Point.Lng 
                    });
                    long idLocationSafePoint = GetIDByPoint(optionals[0].Point);
                    minyanBll.AddMinyan(
                    new MinyanDTO
                    {
                        IDPrayer = timeAlgorithmics.RecognizePrayer(driverLocation),
                        BeginningTimeNavToMinyan=DateTime.Now.TimeOfDay,
                        DateMinyan=DateTime.Now,
                        IDLocationMinyan=idLocationSafePoint,
                        NumOfPeopleInMinyan=1,
                        SuccessfullyMinyan=false
                    });
                    long idMinyan = GetIdMinyanByIdPoint(idLocationSafePoint);

                    AsksToMinyanDTO asksToMinyan = new AsksToMinyanDTO
                    {
                        IdMinyan = idMinyan,
                        IdAskMinyan = idAskMinyan
                    };
                     asksToMinyanBLL.AddAsksToMinyan(asksToMinyan);

                    return asksToMinyan;
            }
        }

        private long GetIDByPoint(LocationPoint point)
        {
            List<SafePointOnTheWayDTO> safes = safePointOnTheWayBLL.GetSafePointOnTheWays();
            foreach (var safe in safes)
            {
                if(safe.Lat == point.Lat && safe.Lng == point.Lng)
                {
                    return safe.IdlocationMinyan;
                }
            }
            return -1;
        }
        private long GetIdMinyanByIdPoint(long idPoint)
        {
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach (var minyan in minyans)
            {
                if (minyan.IDLocationMinyan == idPoint)
                {
                    return minyan.IDMinyan;
                }
            }
            return -1;
        }
        public AsksToMinyanDTO DriverOptions(LocationPoint driverLocation, long idAskMinyan)
        {
            List<MinyanDTO> driverOptions = SearchMatchMinyan(driverLocation);
            int c = driverOptions.Count;
            switch (c)
            {
                case 0:return CreateMinyan(driverLocation,idAskMinyan);
                  
                case 1:AddPrayerToMinyan(driverOptions[0].IDMinyan);
                    AsksToMinyanDTO asksToMinyan = new AsksToMinyanDTO
                    {
                        IdMinyan = driverOptions[0].IDMinyan,
                        IdAskMinyan = idAskMinyan
                    };
                    asksToMinyanBLL.AddAsksToMinyan(asksToMinyan);
                    return asksToMinyan;
                    
                default:return ShowAndChooseMinyans(driverOptions);
                
            }
            
        }
    }
}
