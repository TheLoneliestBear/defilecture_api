using defilectureWebApiRest.Models.Equipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace defilectureWebApiRest.Controllers
{
    public class EquipeController : ApiController
    {
        [Route("api/Equipes")]
        public IEnumerable<Equipe> Get()
        {
            return EquipeDataProvider.GetEquipes();
        }


        // GET api/<controller>/compte/15
        [Route("api/Equipe/{id}")]
        public IEnumerable<Equipe> Get(int id)
        {
            return EquipeDataProvider.GetEquipeById(id);
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