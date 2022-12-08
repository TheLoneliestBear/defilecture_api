using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using defilectureWebApiRest.Models.DemandeEquipe;

namespace defilectureWebApiRest.Controllers
{
    public class DemandeEquipeController : ApiController
    {

        //ajouter une demande d'équipe:
        public bool Put(DemandeEquipe demande)
        {
            return DemandeEquipeDataProvider.AjouterDemandeEquipage(demande);
        }   

        //afficher toute les demande:
        public IEnumerable<DemandeEquipe> Get()
        {
            return DemandeEquipeDataProvider.getDemandes();
        }

        //afficher selon le idEquipe:
        public IEnumerable<DemandeEquipe> GetSelonIdEquipe(int idEquipe)
        {
            return DemandeEquipeDataProvider.afficherDemandeSelonIdEquipe(idEquipe);
        }

        //afficher selon le idCompte:

        public IHttpActionResult GetSelonIdCompte(int idCompte)
        {
            DemandeEquipe demande = DemandeEquipeDataProvider.afficherDemandeSelonIdCompte(idCompte);
            if(demande != null)
            {
                return this.Ok(demande);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}