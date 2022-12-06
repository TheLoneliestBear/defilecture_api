using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace defilectureWebApiRest.Models.Defi
{
    [DataContract]
    public class Defi
    {
        [DataMember]
        public int idDefi { get; set; }
        [DataMember]
        public int idCompte { get; set; }
        [DataMember]
        public string nom { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string dateDebut { get; set; }
        [DataMember]
        public string dateFin { get; set; }
        [DataMember]
        public string question { get; set; }
        [DataMember]
        public string choixReponseA { get; set; }
        [DataMember]
        public string choixReponseB { get; set; }
        [DataMember]
        public string choixReponseC { get; set; }
        [DataMember]
        public string choixReponseD { get; set; }
        [DataMember]
        public int valeurMinute { get; set; }

        public override string ToString()
        {
            return string.Format(" Defi # : {}, Compte # : {}, Nom: {}, Description: {}, Date du Debut : {}, Date de Fin : {}, Question: {}, Reponse A: {}, Reponse B : {}, Reponse C: {}, Reponse D: {}, Valeur Minutes : {}",
                idDefi, idCompte, nom, description, dateDebut, dateFin, question, choixReponseA, choixReponseB, choixReponseC, choixReponseD, valeurMinute);
        }
    }
}