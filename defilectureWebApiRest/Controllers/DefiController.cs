using defilectureWebApiRest.Models.Defi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace defilectureWebApiRest.Controllers
{
    public class DefiController : ApiController
    {
        //Trouver defi par id :
        [HttpGet]
        [Route("api/Defi/{id}")]
        public Defi Get(int id)
        {
            return DefiDataProvider.FindByIdDefi(id);
        }
    }
}