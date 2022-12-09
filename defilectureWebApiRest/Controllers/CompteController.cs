using defilectureWebApiRest.Models;
using defilectureWebApiRest.Models.Compte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace defilectureWebApiRest.Controllers
{
    public class CompteController : ApiController
    {







        //Trouver comptes par idEquipe :
        [Route("api/Comptes/idEquipe/{idEquipe}")]
        public IEnumerable<Compte> GetParIdEquipe(int idEquipe)
        {
            return CompteDataProvider.GetListeCompteDansUneEquipe(idEquipe);
        }


        //Trouver compte par courriel :
        [Route("api/Comptes/courriel/{courriel}")]
        public IHttpActionResult GetByCourriel(string courriel)
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
        [Route("api/Comptes/nom/{nom}")]
        public IHttpActionResult GetByNom(string nom)
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
        [Route("api/Comptes/prenom/{prenom}")]
        public IHttpActionResult GetByPrenom(string prenom)
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
        [Route("api/Comptes/pseudo/{pseudo}")]
        public IHttpActionResult GetByPseudo(string pseudo)
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
        [Route("api/Comptes/role/{role}")]
        public IEnumerable<Compte> GetByRole(int role)
        {
            return CompteDataProvider.GetComptesByRole(role);
        }

        //Trouver compte par programme :
        [Route("api/Comptes/programme/{programme}")]
        public IEnumerable<Compte> GetByProgramme(string programme)
        {
            return CompteDataProvider.GetComptesByProgramme(programme);
        }

        //Trouver compte par Capitaine:
        [Route("api/Comptes/capitaine/{capitaine}")]
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