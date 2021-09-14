using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL.Converts
{
    public class MinyanConvert
    {
        public static MinyanDTO ConvertDALToDTO(Minyan minyan)
        {
            MinyanDTO minyanDTO = new MinyanDTO();
            minyanDTO.IDMinyan = minyan.IdMinyan;
            minyanDTO.IDPrayer = minyan.IdPrayer;
            minyanDTO.DateMinyan = minyan.DateMinyan;
            minyanDTO.BeginningTimeNavToMinyan = minyan.BeginningTimeNavToMinyan;
            minyanDTO.IDLocationMinyan = minyan.IdlocationMinyan;
            minyanDTO.NumOfPeopleInMinyan = minyan.NumOfPeopleInMinyan;
            minyanDTO.SuccessfullyMinyan = minyan.SuccessfullyMinyan;
            return minyanDTO;

        }
        public static Minyan ConvertDTOToDAL(MinyanDTO minyanDTO)
        {
            Minyan minyan = new Minyan();
            minyan.IdMinyan = minyanDTO.IDMinyan;
            minyan.IdPrayer = minyanDTO.IDPrayer;
            minyan.DateMinyan = minyanDTO.DateMinyan;
            minyan.BeginningTimeNavToMinyan = minyanDTO.BeginningTimeNavToMinyan;
            minyan.IdlocationMinyan = minyanDTO.IDLocationMinyan;
            minyan.NumOfPeopleInMinyan = minyanDTO.NumOfPeopleInMinyan;
            minyan.SuccessfullyMinyan = minyanDTO.SuccessfullyMinyan;
            return minyan;

        }
        public static List<MinyanDTO> ConvertDALToDTOList(ICollection<Minyan> minyans)
        {
            return minyans.Select(m => ConvertDALToDTO(m)).ToList();
        }
        public static ICollection<Minyan> ConvertDTOToDALList(List<MinyanDTO> minyans)
        {
            return minyans.Select(m => ConvertDTOToDAL(m)).ToList();
        }
    }
}
