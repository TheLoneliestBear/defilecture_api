using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace defilectureWebApiRest.Models.Compte
{
    public class CompteDataProvider
    {
        private static string connectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=defilecture";


        public static List<Compte> GetComptes()
        {
            List<Compte> liste = new List<Compte>();
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM compte";
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                compte = new Compte
                {
                    idCompte = Convert.ToInt32(dr["ID_COMPTE"]),
                    idEquipe = Convert.ToInt32(dr["ID_EQUIPE"]),
                    courriel = dr["COURRIEL"].ToString(),
                    motDePasse = dr["MOT_PASSE"].ToString(),
                    nom = dr["NOM"].ToString(),
                    prenom = dr["PRENOM"].ToString(),
                    point = Convert.ToInt32(dr["POINT"]),
                    programme = dr["PROGRAMME_ETUDE"].ToString(),
                    avatar = dr["AVATAR"].ToString(),
                    pseudo = dr["PSEUDONYME"].ToString(),
                    role = Convert.ToInt32(dr["ROLE"]),
                    devenirCapitaine = Convert.ToBoolean(dr["DEVENIR_CAPITAINE"])
                };
                liste.Add(compte);
            }
            cnx.Close();
            return liste;
        }

        public static Compte FindByIdCompte(int id)
        {
            Compte c;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE ID_COMPTE =@id";
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
                c = new Compte
                {
                    idCompte = Convert.ToInt32(dr["ID_COMPTE"]),
                    idEquipe = Convert.ToInt32(dr["ID_EQUIPE"]),
                    courriel = dr["COURRIEL"].ToString(),
                    motDePasse = dr["MOT_PASSE"].ToString(),
                    nom = dr["NOM"].ToString(),
                    prenom = dr["PRENOM"].ToString(),
                    point = Convert.ToInt32(dr["POINT"]),
                    programme = dr["PROGRAMME_ETUDE"].ToString(),
                    avatar = dr["AVATAR"].ToString(),
                    pseudo = dr["PSEUDONYME"].ToString(),
                    role = Convert.ToInt32(dr["ROLE"]),
                    devenirCapitaine = Convert.ToBoolean(dr["DEVENIR_CAPITAINE"])
                };
                return c;
            }
            cnx.Close();
            return null;
        }

        public static Compte FindCompteByPseudoMdp(string pseudonyme, string mdp)
        {
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE PSEUDONYME = @pseudonyme AND MOT_PASSE = @mdp;";
            DbParameter param; 
            param = new MySqlParameter
            {
                ParameterName = "pseudonyme",
                DbType = System.Data.DbType.String,
                Value = pseudonyme
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "mdp",
                DbType = System.Data.DbType.String,
                Value = mdp
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                compte = new Compte
                {
                    idCompte = Convert.ToInt32(dr["ID_COMPTE"]),
                    idEquipe = Convert.ToInt32(dr["ID_EQUIPE"]),
                    courriel = dr["COURRIEL"].ToString(),
                    motDePasse = dr["MOT_PASSE"].ToString(),
                    nom = dr["NOM"].ToString(),
                    prenom = dr["PRENOM"].ToString(),
                    point = Convert.ToInt32(dr["POINT"]),
                    programme = dr["PROGRAMME_ETUDE"].ToString(),
                    avatar = dr["AVATAR"].ToString(),
                    pseudo = dr["PSEUDONYME"].ToString(),
                    role = Convert.ToInt32(dr["ROLE"]),
                    devenirCapitaine = Convert.ToBoolean(dr["DEVENIR_CAPITAINE"])
                };
                return compte;
            }
            cnx.Close();
            return null;
        }
    }
}