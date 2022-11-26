using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Defi_Lecture_API.Models
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int idQuestion { get; set; }
        [DataMember]
        public string question { get; set; }
        [DataMember]
        public string bonneReponse { get; set; }
        [DataMember]
        public string mauvaiseReponse { get; set; }

    }
}