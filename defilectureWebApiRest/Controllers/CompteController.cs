using defilectureWebApiRest.Models;
using defilectureWebApiRest.Models.Compte;
using defilectureWebApiRest.Models.Lecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace defilectureWebApiRest.Controllers
{
    public class CompteController : ApiController
    {
        //Initialisation de la liste des comptes
        public CompteController()
        {
           // ComptesDao.Remplir();
        }

        [HttpGet]
        [Route("api/Compte/{pseudo}/{mdp}")]
        public Compte Get(string pseudo, string mdp)
        {
            return CompteDataProvider.FindCompteByPseudoMdp(pseudo,mdp);
        }

        /*
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
       
        //Trouver compte par idEquipe :

        //Trouver compte par courriel :

        //Trouver compte par nom :

        //Trouver compte par prenom :

        //Trouver compte par pseudo :

        //Trouver compte par role :

        //Trouver compte par programme :

        //Trouver compte par Capitaine:

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
 */
        //Se connecter :

        //S'inscrire :

    }
}