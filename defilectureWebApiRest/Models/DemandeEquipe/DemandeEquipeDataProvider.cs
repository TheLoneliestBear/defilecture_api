using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using defilectureWebApiRest.Models.Compte;
using MySql.Data.MySqlClient;

namespace defilectureWebApiRest.Models.DemandeEquipe
{
    public class DemandeEquipeDataProvider
    {

        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=defilecture";

        public static bool AjouterDemandeEquipage(DemandeEquipe equipe)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "INSERT INTO demande_equipe(ID_COMPTE, ID_EQUIPE) VALUES (@idCompte, @idEquipe)";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "idCompte",
                DbType = System.Data.DbType.Int32,
                Value = equipe.idCompte
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "idEquipe",
                DbType = System.Data.DbType.Int32,
                Value = equipe.idEquipe
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

        public static List<DemandeEquipe> getDemandes() 
        {
            List<DemandeEquipe> demandeListe = new List<DemandeEquipe>();
            DemandeEquipe demandeEquipe;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM demande_equipe";
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                demandeEquipe = new DemandeEquipe()
                {
                    idDemande = (int)dr["ID_DEMANDE_EQUIPE"],
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    point = (int)dr["POINT"],
                    statutDemande = (int)dr["STATUT_DEMANDE"]
                };
                demandeListe.Add(demandeEquipe);
            }
            conn.Close();
            return demandeListe;
        }

        public static DemandeEquipe afficherDemandeSelonIdCompte(int idCompte)
        {
            DemandeEquipe demandeEquipe;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM demande_equipe WHERE ID_COMPTE=@idCompte";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "idCompte",
                DbType = System.Data.DbType.Int32,
                Value = idCompte
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                demandeEquipe = new DemandeEquipe
                {
                    idDemande = (int)dr["ID_DEMANDE_EQUIPE"],
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    point = (int)dr["POINT"],
                    statutDemande = (int)dr["STATUT_DEMANDE"]
                };
                return demandeEquipe;
            }
            cnx.Close();
            return null;
        }

        public static List<DemandeEquipe> afficherDemandeSelonIdEquipe (int idEquipe) 
        {
            List<DemandeEquipe> demandeListe = new List<DemandeEquipe>();
            DemandeEquipe demandeEquipe;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM demande_equipe WHERE ID_COMPTE=@idEquipe";
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
                demandeEquipe = new DemandeEquipe()
                {
                    idDemande = (int)dr["ID_DEMANDE_EQUIPE"],
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    point = (int)dr["POINT"],
                    statutDemande = (int)dr["STATUT_DEMANDE"]
                };
                demandeListe.Add(demandeEquipe);
            }
            conn.Close();
            return demandeListe;

        }

    }
}