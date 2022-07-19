using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
  public  interface IFournisseurRepository
    {
        //Tout les fournisseurs
       Task<IEnumerable<Fournisseur>> AllFsseurs();

        //Tout les fournisseurs actif
        Task<IEnumerable<Fournisseur>> AllActifFsseurs();

        //Un FOurnisseur
        Task<Fournisseur> GetFsseur(int id);

        //Creer Fsseur
        Task CreateFsseur(Fournisseur fsseur);

        //Supprimmer Fsseur
        Task DeleteFsseur(int id);

        //Modifier Fsseur
        Task UpdateFsseur(Fournisseur fsseur);

    }
}
