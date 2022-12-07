using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace defilectureWebApiRest.Models.Compte
{
    public class CompteDataProvider
    {
        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=defilecture";

        public static List<Compte> GetListeCompteDansUneEquipe(int id_Equipe)
        {
            List<Compte> compteListe = new List<Compte>();
            Compte compte;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM compte WHERE ID_EQUIPE = @id_Equipe";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "id_Equipe",
                DbType = System.Data.DbType.Int16,
                Value = id_Equipe
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                compte = new Compte()
                {
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    courriel = (string)dr["COURRIEL"],
                    motDePasse = (string)dr["MOT_PASSE"],
                    nom = (string)dr["NOM"],
                    prenom = (string)dr["PRENOM"],
                    point = (int)dr["Point"],
                    programme = (string)dr["PROGRAMME_ETUDE"],
                    avatar = (string)dr["AVATAR"],
                    pseudo = (string)dr["PSEUDONYME"],
                    role = (int)dr["ROLE"],
                    devenirCapitaine = (bool)dr["DEVENIR_CAPITAINE"]
                };
                compteListe.Add(compte);
            }
            conn.Close();
            return compteListe;
        }

    }
}