using Defi_Lecture_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Defi_Lecture_API.Controllers
{
    public class ComptesDao
    {

        //Implémenter la bd

        static List<Compte> comptes;

        public static void Remplir()
        {
            if (comptes == null)
            {
                comptes = new List<Compte>();
                comptes.Add(new Compte { idCompte = 01, idEquipe = 001, courriel = "bob@gmail.com", motDePasse = "12345", nom = "Marley", prenom = "Bob", pseudo = "Prof", role =  2, avatar = "tête-de-mort.png", point = 15, programme = "Info", devenirCapitaine = true });
                comptes.Add(new Compte { idCompte = 02, idEquipe = 001, courriel = "max@gmail.com", motDePasse = "12345", nom = "Reinhart", prenom = "Max", pseudo = "Étu1", role = 1, avatar = "tête-de-mort.png", point = 30, programme = "Info", devenirCapitaine = false });
                comptes.Add(new Compte { idCompte = 03, idEquipe = 001, courriel = "tom@gmail.com", motDePasse = "12345", nom = "Shelbey", prenom = "Tom", pseudo = "Étu2", role = 1, avatar = "tête-de-mort.png", point = 60, programme = "Info", devenirCapitaine = false });

            }
        }

        public static List<Compte> FindAll()
        {
            return comptes;
        }

        public static Compte FindByIdCompte(int idCompte)
        {
            return comptes.Where(x => x.idCompte == idCompte).FirstOrDefault();
        }

        public static void Ajouter(Compte o)
        {
            comptes.Add(o);
        }

        public static bool Modifier(Compte o)
        {
            foreach (Compte item in comptes)
            {
                if (item.idCompte == o.idCompte)
                {
                    item.idEquipe = o.idEquipe;
                    item.courriel = o.courriel;
                    item.motDePasse = o.motDePasse;
                    item.nom = o.nom;
                    item.prenom = o.prenom;
                    item.pseudo = o.pseudo;
                    item.role = o.role;
                    item.avatar = o.avatar;
                    item.point = o.point;
                    item.programme = o.programme;
                    item.devenirCapitaine = o.devenirCapitaine;
                    return true;
                }
            }
            return false;
        }

        public static bool Supprimer(int idCompte)
        {
            Compte item = FindByIdCompte(idCompte);
            if (item != null)
            {
                return comptes.Remove(item);
            }
            return false;
        }

        //Se connecter

        //s'inscrire

    }
}