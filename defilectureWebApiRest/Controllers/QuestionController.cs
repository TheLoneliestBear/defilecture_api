//using defilectureWebApiRest.Models.Question;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;

//namespace defilectureWebApiRest.Controllers
//{
//    public class QuestionController : ApiController
//    {
//        //Initialisation de la liste des questions
//        public QuestionController()
//        {
//            QuestionsDao.Remplir();
//        }


//        //Trouver tous les questions
//        // GET api/<controller>
//        public IEnumerable<Question> Get()
//        {
//            return QuestionsDao.FindAll();
//        }

//        //Trouver les question par idQuestion :
//        public IHttpActionResult Get(int idQuestion)
//        {
//            Question question = QuestionsDao.FindByIdQuestion(idQuestion);
//            if (question != null)
//            {
//                return this.Ok(question);
//            }
//            else
//            {
//                return this.NotFound();
//            }
//        }

//        //Trouver tous les bonnes réponses :

//        //Trouver tous les mauvaises réponses :

//        //Ajout de question :
//        // POST api/<controller>
//        public void Post(Question question)
//        {
//            QuestionsDao.Ajouter(question);
//        }

//        //Modification de question :
//        // PUT api/<controller>/5
//        public void Put(Question question)
//        {
//            QuestionsDao.Modifier(question);
//        }

//        //Suppression de question :
//        // DELETE api/<controller>/9584512
//        public bool Delete(int idQuestion)
//        {
//            return QuestionsDao.Supprimer(idQuestion);
//        }
//    }

//}