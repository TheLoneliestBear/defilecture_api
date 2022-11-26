using Defi_Lecture_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Defi_Lecture_API.Controllers
{
    public class QuestionsDao
    {

        //Implémenter la bd

        static List<Question> questions;

        public static void Remplir()
        {
            if (questions == null)
            {
                questions = new List<Question>();
                questions.Add(new Question { idQuestion = 01, question = "Est-ce que Harry Potter était un muggle?", bonneReponse = "Oui", mauvaiseReponse = "Non"});
                questions.Add(new Question { idQuestion = 02, question = "Est-ce qu'il y avait des dragons dans Harry Potter?", bonneReponse = "Oui", mauvaiseReponse = "Non" });
                questions.Add(new Question { idQuestion = 03, question = "Est-ce que le nom du protagonist dans Harry Potter est Harry Potter?", bonneReponse = "Oui", mauvaiseReponse = "Non" });
            }
        }

        public static List<Question> FindAll()
        {
            return questions;
        }

        public static Question FindByIdQuestion(int idQuestion)
        {
            return questions.Where(x => x.idQuestion == idQuestion).FirstOrDefault();
        }

        public static void Ajouter(Question o)
        {
            questions.Add(o);
        }

        public static bool Modifier(Question o)
        {
            foreach (Question item in questions)
            {
                if (item.idQuestion == o.idQuestion)
                {
                    item.question = o.question;
                    item.bonneReponse = o.bonneReponse;
                    item.mauvaiseReponse = o.mauvaiseReponse;
                    return true;
                }
            }
            return false;
        }

        public static bool Supprimer(int idQuestion)
        {
            Question item = FindByIdQuestion(idQuestion);
            if (item != null)
            {
                return questions.Remove(item);
            }
            return false;
        }

    }
}