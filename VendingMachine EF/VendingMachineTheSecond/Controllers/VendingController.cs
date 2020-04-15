using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VendingMachineTheSecond.Models;

namespace VendingMachineTheSecond.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendingController : ApiController
    {
        [Route("vending/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(ItemRepository.GetAll());
        }

        [Route("vending/purchase/{id}/{money}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Purchase(int id, decimal money)
        {
            return Ok(ItemRepository.Purchase(id, money));
        }
    }
}
