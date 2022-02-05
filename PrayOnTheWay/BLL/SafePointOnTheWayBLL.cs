using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SafePointOnTheWayBLL
    {
        SafePointOnTheWayDAL safePointOnTheWayDAL = new SafePointOnTheWayDAL();
        public bool AddSafePointOnTheWay(SafePointOnTheWayDTO safePointOnTheWay)
        {
            return safePointOnTheWayDAL.AddSafePointOnTheWay(Converts.SafePointOnTheWayConvert.ConvertDTOToDAL(safePointOnTheWay));
        }
        public List<SafePointOnTheWayDTO> GetSafePointOnTheWays()
        {
            return Converts.SafePointOnTheWayConvert.ConvertDALToDTOList(safePointOnTheWayDAL.GetSafePointOnTheWays());
        }
        public bool UpdateSafePointOnTheWay(SafePointOnTheWayDTO safePointOnTheWay)
        {
            return safePointOnTheWayDAL.UpdateSafePointOnTheWay(Converts.SafePointOnTheWayConvert.ConvertDTOToDAL(safePointOnTheWay));
        }
        public bool RemoveSafePointOnTheWay(SafePointOnTheWayDTO safePointOnTheWay)
        {
            return safePointOnTheWayDAL.RemoveSafePointOnTheWay(Converts.SafePointOnTheWayConvert.ConvertDTOToDAL(safePointOnTheWay));
        }
    }
}
