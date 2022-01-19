using BLL.Algoritmics;
using BLL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]

    public class SelectMinyanController : ApiController
    {
        MinyanAlgorithmics minyanAlgorithmics = new MinyanAlgorithmics();

        [HttpPost]
        public SelectMinyan[] DataToSelectionMinyan(LocationPoint location)
        {
            List<MinyanDTO> driverOptions = minyanAlgorithmics.SearchMatchMinyan(location);
            List<SelectMinyan> selectMinyan = minyanAlgorithmics.ShowAndChooseMinyans(location, driverOptions);
            SelectMinyan[] selectMinyans = new SelectMinyan[selectMinyan.Count];
            int i = 0;
            foreach(SelectMinyan sm in selectMinyans)
            {
                selectMinyans[i] = sm;
                i++;
            }
            return selectMinyans;
        }

        //public SelectMinyan[] DataToSelectionMinyans()
        //{
              
        //}




          




        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}