using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class ManagerBLL
    {
        public bool LoginManager(string userName,string password)
        {
            return (userName == ConfigurationManager.AppSettings["managerUserName"] && password == ConfigurationManager.AppSettings["managerPassword"]);
        }
    }
}
