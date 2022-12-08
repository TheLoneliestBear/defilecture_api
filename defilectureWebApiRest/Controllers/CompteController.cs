using defilectureWebApiRest.Models;
using defilectureWebApiRest.Models.Compte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace defilectureWebApiRest.Controllers
{
    public class CompteController : ApiController
    {
        //Initialisation de la liste des comptes
        public CompteController()
        {
            ComptesDao.Remplir();
        }


        //Trouver tous les comptes
        // GET api/<controller>
        public IEnumerable<Compte> Get()
        {
            return ComptesDao.FindAll();
        }


        //Trouver compte par idCompte :
        public IHttpActionResult Get(int idCompte)
        {
            Compte compte = ComptesDao.FindByIdCompte(idCompte);
            if (compte != null)
            {
                return this.Ok(compte);
            }
            else
            {
                return this.NotFound();
            }
        }

        //Trouver comptes par idEquipe :
        public IEnumerable<Compte> GetByIdEquipe(int idEquipe)
        {
            return CompteDataProvider.GetListeCompteDansUneEquipe(idEquipe);
        }


        //Trouver compte par courriel :
        public IHttpActionResult getByCourriel(string courriel)
        {
            Compte compte = CompteDataProvider.FindByCourriel(courriel);
            if (compte != null)
            {
                return this.Ok(compte);
            }
            else
            {
                return this.NotFound();
            }
        }

        //Trouver compte par nom :
        public IHttpActionResult getByNom(string nom)
        {
            Compte compte = CompteDataProvider.FindByNom(nom);
            if (compte != null)
            {
                return this.Ok(compte);
            }
            else
            {
                return this.NotFound();
            }
        }


        //Trouver compte par prenom :
        public IHttpActionResult getByPrenom(string prenom)
        {
            Compte compte = CompteDataProvider.FindByPrenom(prenom);
            if (compte != null)
            {
                return this.Ok(compte);
            }
            else
            {
                return this.NotFound();
            }
        }

        //Trouver compte par pseudo :
        public IHttpActionResult getByPseudo(string pseudo)
        {
            Compte compte = CompteDataProvider.FindByPseudo(pseudo);
            if (compte != null)
            {
                return this.Ok(compte);
            }
            else
            {
                return this.NotFound();
            }
        }

        //Trouver compte par role :
        public IEnumerable<Compte> GetByRole(int role)
        {
            return CompteDataProvider.GetComptesByRole(role);
        }

        //Trouver compte par programme :
        public IEnumerable<Compte> GetByProgramme(string programme)
        {
            return CompteDataProvider.GetComptesByProgramme(programme);
        }

        //Trouver compte par Capitaine:
        public IEnumerable<Compte> GetByCapitaine(bool capitaine)
        {
            return CompteDataProvider.GetComptesByCapitaine(capitaine);
        }

        //Ajout de compte :
        // POST api/<controller>
        public void Post(Compte compte)
        {
            ComptesDao.Ajouter(compte);
        }

        //Modification de compte :
        // PUT api/<controller>/5
        public void Put(Compte compte)
        {
            ComptesDao.Modifier(compte);
        }

        //Suppression de compte :
        // DELETE api/<controller>/9584512
        public bool Delete(int idCompte)
        {
            return ComptesDao.Supprimer(idCompte);
        }

        //Se connecter :

        //S'inscrire :

    }
}