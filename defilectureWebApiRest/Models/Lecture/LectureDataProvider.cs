using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace defilectureWebApiRest.Models.Lecture
{

    
    public class LectureDataProvider
    {
        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=defilecture";

        
        public static List<Lecture> GetLectures()
        {
            List<Lecture> liste = new List<Lecture>();
            Lecture lecture;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM lecture";
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                lecture = new Lecture
                {
                    idLecture = (int)dr["ID_LECTURE"],
                    idCompte = (int)dr["ID_COMPTE"],
                    titre = dr["TITRE"].ToString(),
                    dateInscription = dr["DATE_INSCRIPTION"].ToString(),
                    tempsLu = (int)dr["DUREE_MINUTES"],
                    estObligatoire = (bool)dr["EST_OBLIGATOIRE"]
                };
                liste.Add(lecture);
            }
            cnx.Close();
            return liste;
        }

        public static List<Lecture> GetById(int idCompte)
        {
            List<Lecture> liste = new List<Lecture>();
            Lecture lecture;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM lecture WHERE ID_COMPTE =@idCompte";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "idCompte",
                DbType = System.Data.DbType.Int32,
                Value = idCompte
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lecture = new Lecture
                {
                    idLecture = (int)dr["ID_LECTURE"],
                    idCompte = (int)dr["ID_COMPTE"],
                    titre = dr["TITRE"].ToString(),
                    dateInscription = dr["DATE_INSCRIPTION"].ToString(),
                    tempsLu = (int)dr["DUREE_MINUTES"],
                    estObligatoire = (bool)dr["EST_OBLIGATOIRE"]
                };
                liste.Add(lecture);
            }
            cnx.Close();
            return liste;
        }
        public static bool Supprimer(int idLivre)
        {

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "DELETE FROM lecture WHERE ID_LECTURE = @idLivre";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "idLivre",
                DbType = System.Data.DbType.Int32,
                Value = idLivre
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

    }
}