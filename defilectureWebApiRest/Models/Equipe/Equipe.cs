using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using System.Drawing;

namespace defilectureWebApiRest.Models.Equipe
{
    [DataContract]
    public class Equipe
    {
        public Equipe() { }

        public Equipe(int equipeId, string equipeNom, int equipePoints)
        {
            EquipeId = equipeId;
            EquipeNom = equipeNom;
            EquipePoints = equipePoints;
        }

        [DataMember]
        public int EquipeId { get; set; }
        [DataMember]
        public string EquipeNom { get; set; }
        [DataMember]
        public int EquipePoints { get; set; }

        public override string ToString()
        {
            return string.Format("Numero: {}, Nom: {}, Points: {}",EquipeId, EquipeNom, EquipePoints);
        }
    }
}