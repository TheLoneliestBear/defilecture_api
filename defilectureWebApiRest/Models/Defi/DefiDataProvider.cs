using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Web;

namespace defilectureWebApiRest.Models.Defi
{
    public class DefiDataProvider
    {
        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=;Database=defilecture";


        public static Defi FindByIdDefi(int id)
        {
            Defi d;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM defi WHERE ID_COMPTE =@id";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = System.Data.DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                d = new Defi
                {
                    idDefi = Convert.ToInt32(dr["ID_DEFI"]),
                    idCompte = Convert.ToInt32(dr["ID_COMPTE"]),
                    nom = dr["NOM"].ToString(),
                    description = dr["DESCRIPTION"].ToString(),
                    dateDebut = dr["DATE_DEBUT"].ToString(),
                    dateFin = dr["DATE_FIN"].ToString(),
                    questions = dr["QUESTION"].ToString(),
                    choixReponseA = dr["CHOIX_REPONSE_A"].ToString(),
                    choixReponseB = dr["CHOIX_REPONSE_B"].ToString(),
                    choixReponseC = dr["CHOIX_REPONSE_C"].ToString(),
                    choixReponseD = dr["CHOIX_REPONSE_D"].ToString(),
                    valeurMinute = Convert.ToInt32(dr["VALEUR_MINUTE"]),
                };
                return d;
            }
            cnx.Close();
            return null;
        }

        public static Boolean ValiderReponseDefi(String essai, int idDefi) {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT REPONSE FROM defi_reponse WHERE ID_DEFI =@id";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = System.Data.DbType.Int32,
                Value = idDefi
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                String reponse = dr["REPONSE"].ToString();
                if (reponse == essai) { return true; }
                else { return false; }
            }
            cnx.Close();
            return false;
        }

    }
}