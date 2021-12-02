using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converts
{
    public class SafePointOnTheWayConvert
    {
        public static SafePointOnTheWayDTO ConvertDALToDTO(SafePointOnTheWay safePointOnTheWay)
        {
            SafePointOnTheWayDTO safePointOnTheWayDTO = new SafePointOnTheWayDTO();
            safePointOnTheWayDTO.IdlocationMinyan = safePointOnTheWay.IdlocationMinyan;
            safePointOnTheWayDTO.Lat = safePointOnTheWay.Lat.ToString();
            safePointOnTheWayDTO.Lng = safePointOnTheWay.Lng.ToString();
         //   safePointOnTheWayDTO.Minyans = (MinyanConvert.ConvertDALToDTOList(safePointOnTheWay.Minyans));
            return safePointOnTheWayDTO;
        }
        public static SafePointOnTheWay ConvertDTOToDAL(SafePointOnTheWayDTO safePointOnTheWayDTO)
        {
            SafePointOnTheWay safePointOnTheWay = new SafePointOnTheWay();
            safePointOnTheWay.IdlocationMinyan = safePointOnTheWayDTO.IdlocationMinyan;
            safePointOnTheWay.Lat = (safePointOnTheWayDTO.Lat);
            safePointOnTheWay.Lng = (safePointOnTheWayDTO.Lng);
           // safePointOnTheWay.Minyans = (MinyanConvert.ConvertDTOToDALList(safePointOnTheWayDTO.Minyans));
            return safePointOnTheWay;
        }

        public static List<SafePointOnTheWayDTO> ConvertDALToDTOList(ICollection<SafePointOnTheWay> safePointOnTheWays)
        {
            return safePointOnTheWays.Select(m => ConvertDALToDTO(m)).ToList();
        }
        public static ICollection<SafePointOnTheWay> ConvertDTOToDALList(List<SafePointOnTheWayDTO> safePointOnTheWays)
        {
            return safePointOnTheWays.Select(m => ConvertDTOToDAL(m)).ToList();
        }

    }
}
