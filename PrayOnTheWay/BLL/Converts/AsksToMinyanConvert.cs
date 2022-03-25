using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converts
{
    public class AsksToMinyanConvert  
    {
        public static AsksToMinyanDTO ConvertDALToDTO(AsksToMinyan asksToMinyan)
        {
            return new AsksToMinyanDTO
            {
                IdAskMinyan = asksToMinyan.IdAskMinyan,
                IdMinyan = asksToMinyan.IdMinyan,
                IdAsksToMinyan = asksToMinyan.IdAsksToMinyan,
                IsComming = asksToMinyan.IsComming,
                Message = asksToMinyan.Message,
                //Minyan = MinyanConvert.ConvertDALToDTO(asksToMinyan.Minyan),
               // AskMinyan =AskMinyanConvert.ConvertDALToDTO(asksToMinyan.AskMinyan)
            };
        }
        public static AsksToMinyan ConvertDTOToDAL(AsksToMinyanDTO asksToMinyanDTO)
        {
            return new AsksToMinyan
            {
                IdAskMinyan = asksToMinyanDTO.IdAskMinyan,
                IdAsksToMinyan = asksToMinyanDTO.IdAsksToMinyan,
                IdMinyan = asksToMinyanDTO.IdMinyan,
                IsComming = asksToMinyanDTO.IsComming,
                Message = asksToMinyanDTO.Message,
                // AskMinyan =AskMinyanConvert.ConvertDTOToDAL(asksToMinyanDTO.AskMinyan),
                // Minyan =MinyanConvert.ConvertDTOToDAL(asksToMinyanDTO.Minyan)
            };
        }

        public static List<AsksToMinyanDTO> ConvertDALToDTOList(ICollection<AsksToMinyan> askToMinyans)
        {
            return askToMinyans.Select(a => ConvertDALToDTO(a)).ToList();
        }
        public static ICollection<AsksToMinyan> ConvertDTOToDALList(List<AsksToMinyanDTO> askToMinyans)
        {
            return askToMinyans.Select(a => ConvertDTOToDAL(a)).ToList();
             
               
        }
    }
}
