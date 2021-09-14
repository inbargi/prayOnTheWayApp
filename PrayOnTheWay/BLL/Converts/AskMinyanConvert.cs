using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converts
{
    public class AskMinyanConvert
    {
        public static AskMinyanDTO ConvertDALToDTO(AskMinyan askMinyan)
        {
            return new AskMinyanDTO
            {
                IdAskMinyan = askMinyan.IdAskMinyan,
                AskTime=askMinyan.AskTime,
                IdPrayer=askMinyan.IdPrayer,
                Prayer=PrayerConvert.ConvertDALToDTO(askMinyan.Prayer),
                Lat=askMinyan.Lat,
                Lng=askMinyan.Lng,
                //AsksToMinyans=AsksToMinyanConvert.ConvertDALToDTOList(askMinyan.AsksToMinyans)
            };
        }
        public static AskMinyan ConvertDTOToDAL(AskMinyanDTO askMinyanDTO)
        {
            return new AskMinyan
            {
                IdAskMinyan = askMinyanDTO.IdAskMinyan,
                AskTime = askMinyanDTO.AskTime,
                IdPrayer = askMinyanDTO.IdPrayer,
                Prayer = PrayerConvert.ConvertDTOToDAL(askMinyanDTO.Prayer),
                Lat = askMinyanDTO.Lat,
                Lng = askMinyanDTO.Lng,
               // AsksToMinyans = AsksToMinyanConvert.ConvertDTOToDALList(askMinyanDTO.AsksToMinyans)
            };
        }

        public static List<AskMinyanDTO> ConvertDALToDTOList(ICollection<AskMinyan> askToMinyans)
        {
            return askToMinyans.Select(a => ConvertDALToDTO(a)).ToList();
        }
        public static ICollection<AskMinyan> ConvertDTOToDALList(List<AskMinyanDTO> askToMinyans)
        {
            return askToMinyans.Select(a => ConvertDTOToDAL(a)).ToList();


        }
    }
}
