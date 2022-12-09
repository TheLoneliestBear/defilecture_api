using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace defilectureWebApiRest.Models.Equipe
{
    public class EquipeDataProvider
    {
        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=defilecture";


        public static List<Equipe>GetEquipes()
        {
            List<Equipe> liste = new List<Equipe>();
            Equipe equipe;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM equipe";
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                equipe = new Equipe
                {
                    EquipeId = (int)dr["ID_EQUIPE"],
                    EquipeNom = "" + dr["NOM"],
                    EquipePoints = (int)dr["POINT"]
                };
                liste.Add(equipe);
            }
            cnx.Close();
            return liste;
        }

        public static List<Equipe> GetEquipeById(int idEquipe)
        {
            List<Equipe> liste = new List<Equipe>();
            Equipe equipe;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM equipe WHERE ID_EQUIPE =@idEquipe";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "idEquipe",
                DbType = System.Data.DbType.Int32,
                Value = idEquipe
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                equipe = new Equipe
                {
                    EquipeId = (int)dr["ID_EQUIPE"],
                    EquipeNom = "" + dr["NOM"],
                    EquipePoints = (int)dr["POINT"]
                };
                liste.Add(equipe);
            }
            cnx.Close();
            return liste;
        }
    }
}