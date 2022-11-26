using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Defi_Lecture_API.Models
{
    [DataContract]
    public class Compte
    {
        [DataMember]
        public int idCompte { get; set; }
        [DataMember]
        public int idEquipe { get; set; }
        [DataMember]
        public string courriel { get; set; }
        [DataMember]
        public string motDePasse { get; set; }
        [DataMember]
        public string nom { get; set; }
        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public string pseudo { get; set; }
        [DataMember]
        public string role { get; set; }
        [DataMember]
        public string avatar { get; set; }
        [DataMember]
        public int point { get; set; }
        [DataMember]
        public string programme { get; set; }
        [DataMember]
        public bool devenirCapitaine { get; set; }
        
    }
}