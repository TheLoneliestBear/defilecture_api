using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace defilectureWebApiRest.Models.DemandeEquipe
{
    [DataContract]
    public class DemandeEquipe
    {
        [DataMember]
        public int idDemande { get; set; }
        [DataMember]
        public int idEquipe { get; set; }
        [DataMember]
        public int idCompte { get; set; }
        [DataMember]
        public int point { get; set; }
        [DataMember]
        public int statutDemande { get; set; }
    }
}