using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Defi_Lecture_API.Models.Lecture
{
    [DataContract]
    public class Lecture
    {
        [DataMember]
        public int idLecture { get; set; }
        [DataMember]
        public int idCompte { get; set; }
        [DataMember]
        public string titre { get; set; }
        [DataMember]
        public string dateInscription { get; set; }
        [DataMember]
        public int tempsLu { get; set; }
        [DataMember]
        public bool estObligatoire { get; set; }


        public override string ToString()
        {
            return string.Format(" Lecture #{} : Titre: {}, Compte: {}, Date: {}, Temps lu : {}, Obligatoire : {} ",
                idLecture, titre, idCompte, dateInscription, tempsLu, estObligatoire);
        }
    }
}