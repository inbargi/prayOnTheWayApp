using BLL;
using BLL.Models;
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
        AskMinyanBLL askMinyanBLL = new AskMinyanBLL();
        AsksToMinyanBLL asksToMinyanBLL = new AsksToMinyanBLL();
        SafePointOnTheWayBLL safePointOnTheWayBLL = new SafePointOnTheWayBLL();
        TimeAlgorithmics timeAlgorithmics = new TimeAlgorithmics();
        LocationAlgorithmics locationAlgorithmics = new LocationAlgorithmics();

        public List<MinyanDTO> SearchMatchMinyan(LocationPoint driverLocation ,long idCurrentPrayer)
        {
            List<MinyanDTO> matchMinyan = new List<MinyanDTO>();
            List<MinyanDTO> minyans = minyanBll.GetMinyans().FindAll(m => m.IDPrayer==idCurrentPrayer);
            foreach (var m in minyans)
            {
                if (IsMinyanActive(m.IDMinyan))
                {
                    
                    LocationPoint destination = locationAlgorithmics.GetLocationByIDMinyan(m.IDLocationMinyan);
                    if (timeAlgorithmics.IsOver18Mins(driverLocation,destination)&&locationAlgorithmics.RouteDistanceInKMOnModeDrive(driverLocation, destination) < LocationAlgorithmics.R)
                    {
                        if (timeAlgorithmics.CheckTimeAlgorithmic(driverLocation, destination))
                            matchMinyan.Add(m);
                    }
                }
            }

            return matchMinyan;
        }

        public void AddPrayerToMinyan(long idMinyan)
        {
            List<MinyanDTO> minyans = minyanBll.GetMinyans();
            foreach (MinyanDTO min in minyans)
            {
                if (min.IDMinyan == idMinyan)
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
        public bool IsMinyanActive(long idMinyan)
        {
            return NumOfPeopleInMinyan(idMinyan) > 0;
        }

        public int MinyansInPercent(long idLocationMinyan)
        {
            Random random = new Random();
            //List<MinyanDTO> minyans = minyanBll.GetMinyans();

            return random.Next(1, 101);
        }
        //create minyan by location and id of the request
        public AsksToMinyanDTO CreateMinyan(LocationPoint driverLocation, long idAskMinyan)
        {
            //find the optional location
            List<OptionalLocation> optionals = locationAlgorithmics.FindOptionalLocations(driverLocation);
            //saving the number of optional location
            int c = optionals.Count;
            //according to number
            switch (c)
            {
                //if there is not one
                case 0:
                    {
                        //saving error message at class and return null
                        ErrorServiceClass.error = 4;
                        return null;
                    }
                //if there is at least one
                default:
                    { 
                    //saving the safe point
                    long idLocationSafePoint = safePointOnTheWayBLL.AddSafePointOnTheWay(
                        new SafePointOnTheWayDTO
                        {
                            Lat = optionals[0].Point.Lat,
                            Lng = optionals[0].Point.Lng
                        });
                    //create a new minyan according to data
                    long idMinyan = minyanBll.AddMinyan(
                    new MinyanDTO
                    {
                        IDPrayer = timeAlgorithmics.RecognizePrayer(driverLocation),
                        BeginningTimeNavToMinyan = DateTime.Now.TimeOfDay,
                        DateMinyan = DateTime.Now,
                        IDLocationMinyan = idLocationSafePoint,
                        NumOfPeopleInMinyan = 1,
                        SuccessfullyMinyan = false
                    });
                    //Saving request to this minyan and assign iscomming to the value false
                    AsksToMinyanDTO asksToMinyan = new AsksToMinyanDTO
                    {
                        IdMinyan = idMinyan,
                        IdAskMinyan = idAskMinyan,
                        IsComming = false
                    };
                    asksToMinyanBLL.AddAsksToMinyan(asksToMinyan);
                    return asksToMinyan;
                    }
            }
        }

        public long GetIDByPoint(LocationPoint point)
        {
            List<SafePointOnTheWayDTO> safes = safePointOnTheWayBLL.GetSafePointOnTheWays();
            foreach (var safe in safes)
            {
                if (safe.Lat == point.Lat && safe.Lng == point.Lng)
                {
                    return safe.IdlocationMinyan;
                }
            }
            return -1;
        }
        public long GetIdMinyanByIdPoint(long idPoint)
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
        public ResultDTO DriverOptions(LocationPoint driverLocation, long idAskMinyan)
        {
            long idCurrentMinyan = askMinyanBLL.GetAskMinyans().Find(am => am.IdAskMinyan == idAskMinyan).IdPrayer;
            List<MinyanDTO> driverOptions = SearchMatchMinyan(driverLocation,idCurrentMinyan);
            int c = driverOptions.Count;
            ResultDTO r = new ResultDTO();

            switch (c)
            {
                case 0: r.AsksToMinyanDTO= CreateMinyan(driverLocation, idAskMinyan);
                    break;
                    

                case 1:
                    AddPrayerToMinyan(driverOptions[0].IDMinyan);
                    AsksToMinyanDTO asksToMinyan = new AsksToMinyanDTO
                    {
                        IdMinyan = driverOptions[0].IDMinyan,
                        IdAskMinyan = idAskMinyan,
                        IsComming = false
                    };
                    asksToMinyanBLL.AddAsksToMinyan(asksToMinyan);
                    r.AsksToMinyanDTO= asksToMinyan;
                    break;
                default:
                    {
                        List<SelectMinyan> selectMinyans = ShowAndChooseMinyans(driverLocation, driverOptions);
                        //todo send to angular ^\^

                        r.SelectMinyan = selectMinyans;

                        //long idSelected = 1;
                        //return SavingChoose(selectMinyans, idAskMinyan, idSelected);
                        break;

                    }

            }
            r.Error = ErrorServiceClass.error;
            return r;
        }
        public List<SelectMinyan> ShowAndChooseMinyans(LocationPoint driverLocation, List<MinyanDTO> minyans)
        {
            List<SelectMinyan> selectMinyans = new List<SelectMinyan>();
            foreach (MinyanDTO m in minyans)
            {
                LocationPoint locationDestination = locationAlgorithmics.GetLocationByIDMinyan(m.IDMinyan);
                selectMinyans.Add(new SelectMinyan
                {
                    IdMinyan = m.IDMinyan,
                    NumKM = locationAlgorithmics.RouteDistanceInKMOnModeDrive(driverLocation, locationDestination),
                    NumOfPeople = m.NumOfPeopleInMinyan,
                    TimeDriver = locationAlgorithmics.RouteDistanceInSecondOnModeDrive(driverLocation, locationDestination) / 60,
                    PercentSuccess = MinyansInPercent(m.IDLocationMinyan)
                    //todo percentSuccess func
                });
            }
            return selectMinyans;
        }
        //-----מ.ז נבחר מהאנגולר--מספר מזהה של בקשה---רשימת מנינים אפשריים---
        public ResultDTO SavingChoose(List<SelectMinyan> selectMinyans, long idAskMinyan, int idSelected)
        {
            ResultDTO r = new ResultDTO();
            
            AddPrayerToMinyan(selectMinyans[idSelected].IdMinyan);
            AsksToMinyanDTO asksToMinyan = new AsksToMinyanDTO
            {
                IdMinyan = selectMinyans[idSelected].IdMinyan,
                IdAskMinyan = idAskMinyan,
                IsComming = false
            };
            asksToMinyanBLL.AddAsksToMinyan(asksToMinyan);
            r.AsksToMinyanDTO = asksToMinyan;
            r.IdAskMinyan = idAskMinyan;
            return r;
        }
    }

}

