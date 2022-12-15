using defilectureWebApiRest.Models.Compte;
using defilectureWebApiRest.Models.Lecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace defilectureWebApiRest.Controllers
{
    public class LectureController : ApiController
    {

        [Route("api/Lectures")]
        public IEnumerable<Lecture> Get() 
        {
            return LectureDataProvider.GetLectures();
        }

        //Ajout de lecture :
        // POST api/<controller>
        public bool Post(Lecture lecture)
        {
            LectureDataProvider.AjouterLecture( lecture );
        }

        // GET api/<controller>/compte/15
        [Route("api/Lectures/compte/{id}")]
        public IEnumerable<Lecture> Get(int id)
        {
            return LectureDataProvider.GetById(id);
        }

        //Suppression lecture
        public bool Delete(int id)
        {
            return LectureDataProvider.Supprimer(id);
        }
    }
}