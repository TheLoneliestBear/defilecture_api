using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Web.Http.Results;

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
                DbType = System.Data.DbType.Int32,
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
                    point = (int)dr["POINT"],
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
        

        public static Compte FindByCourriel(string courriel)
        {
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE COURRIEL=@courriel";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "courriel",
                DbType = System.Data.DbType.String,
                Value = courriel
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


        public static Compte FindByNom(string nom)
        {
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE NOM=@nom";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = nom
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                compte = new Compte
                {
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    courriel = (string)dr["COURRIEL"],
                    motDePasse = (string)dr["MOT_PASSE"],
                    nom = (string)dr["NOM"],
                    prenom = (string)dr["PRENOM"],
                    point = (int)dr["POINT"],
                    programme = (string)dr["PROGRAMME_ETUDE"],
                    avatar = (string)dr["AVATAR"],
                    pseudo = (string)dr["PSEUDONYME"],
                    role = (int)dr["ROLE"],
                    devenirCapitaine = (bool)dr["DEVENIR_CAPITAINE"]
                };
                return compte;
            }
            cnx.Close();
            return null;
        }

        public static Compte FindByPrenom(string prenom)
        {
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE PRENOM=@prenom";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = prenom
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                compte = new Compte
                {
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    courriel = (string)dr["COURRIEL"],
                    motDePasse = (string)dr["MOT_PASSE"],
                    nom = (string)dr["NOM"],
                    prenom = (string)dr["PRENOM"],
                    point = (int)dr["POINT"],
                    programme = (string)dr["PROGRAMME_ETUDE"],
                    avatar = (string)dr["AVATAR"],
                    pseudo = (string)dr["PSEUDONYME"],
                    role = (int)dr["ROLE"],
                    devenirCapitaine = (bool)dr["DEVENIR_CAPITAINE"]
                };
                return compte;
            }
            cnx.Close();
            return null;
        }

        public static Compte FindByPseudo(string pseudo)
        {
            Compte compte;
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT * FROM compte WHERE PSEUDONYME=@pseudo";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "pseudo",
                DbType = System.Data.DbType.String,
                Value = pseudo
            };
            cmd.Parameters.Add(param);
            DbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                compte = new Compte
                {
                    idCompte = (int)dr["ID_COMPTE"],
                    idEquipe = (int)dr["ID_EQUIPE"],
                    courriel = (string)dr["COURRIEL"],
                    motDePasse = (string)dr["MOT_PASSE"],
                    nom = (string)dr["NOM"],
                    prenom = (string)dr["PRENOM"],
                    point = (int)dr["POINT"],
                    programme = (string)dr["PROGRAMME_ETUDE"],
                    avatar = (string)dr["AVATAR"],
                    pseudo = (string)dr["PSEUDONYME"],
                    role = (int)dr["ROLE"],
                    devenirCapitaine = (bool)dr["DEVENIR_CAPITAINE"]
                };
                return compte;
            }
            cnx.Close();
            return null;
        }

        public static List<Compte> GetComptesByRole(int role)
        {
            List<Compte> compteListe = new List<Compte>();
            Compte compte;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM compte WHERE ROLE = @role";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "role",
                DbType = System.Data.DbType.Int32,
                Value = role
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
                    point = (int)dr["POINT"],
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

        public static List<Compte> GetComptesByProgramme(string programme)
        {
            List<Compte> compteListe = new List<Compte>();
            Compte compte;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM compte WHERE DEVENIR_CAPITAINE = @programme";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "programme",
                DbType = System.Data.DbType.String,
                Value = programme
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
                    point = (int)dr["POINT"],
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

        public static List<Compte> GetComptesByCapitaine(bool isCapitaine)
        {
            List<Compte> compteListe = new List<Compte>();
            Compte compte;
            DbConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM compte WHERE DEVENIR_CAPITAINE = @isCapitaine";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "isCapitaine",
                DbType = System.Data.DbType.Boolean,
                Value = isCapitaine
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
                    point = (int)dr["POINT"],
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

        public static void AjouterCompte(Compte compte)
        {

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText =
                $"INSERT INTO compte(ID_COMPTE, ID_EQUIPE, COURRIEL, MOT_PASSE, NOM, PRENOM, PSEUDONYME, ROLE, AVATAR, Point, PROGRAMME_ETUDE) VALUES ('{compte.idCompte}','{compte.idEquipe}', '{compte.courriel}', '{compte.motDePasse}', '{compte.nom}', '{compte.prenom}', '{compte.pseudo}', '{compte.role}', '{compte.avatar}', '{compte.point}', '{compte.programme}')";
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static bool ModifierCompte(Compte compte)
        {

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "UPDATE compte SET ID_EQUIPE=@idEquipe,COURRIEL=@courriel,MOT_PASSE=@motDePasse,NOM=@nom,PRENOM=@prenom," +
                " PSEUDONYME=@pseudo, ROLE=@role, AVATAR=@avatar, Point=@point, PROGRAMME_ETUDE=@programme, " +
                "DEVENIR_CAPITAINE=@devenirCapitaine " +
                              "WHERE ID_COMPTE=@idCompte";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "idCompte",
                DbType = System.Data.DbType.Int32,
                Value = compte.idEquipe
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "idEquipe",
                DbType = System.Data.DbType.Int32,
                Value = compte.idEquipe
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "courriel",
                DbType = System.Data.DbType.String,
                Value = compte.courriel
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "motDePasse",
                DbType = System.Data.DbType.String,
                Value = compte.motDePasse
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = compte.nom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = compte.prenom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "pseudo",
                DbType = System.Data.DbType.String,
                Value = compte.pseudo
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "role",
                DbType = System.Data.DbType.Int32,
                Value = compte.role
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "avatar",
                DbType = System.Data.DbType.String,
                Value = compte.avatar
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "point",
                DbType = System.Data.DbType.Int32,
                Value = compte.point
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "programme",
                DbType = System.Data.DbType.String,
                Value = compte.programme
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "devenirCapitaine",
                DbType = System.Data.DbType.Boolean,
                Value = compte.devenirCapitaine
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

        public static bool SupprimerCompte(int idCompte)
        {

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connectionString;
            cnx.Open();
            DbCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "DELETE FROM compte WHERE ID_COMPTE = @idCompte";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "idCompte",
                DbType = System.Data.DbType.Int32,
                Value = idCompte
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }
    }
}