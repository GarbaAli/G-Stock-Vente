using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
   public interface IPaiementRepository
    {
        Task<IEnumerable<Paiement>> AllPaiement();

        Task<IEnumerable<Paiement>> AllPaiementActif();

        Task<Paiement> GetPaiement(int id);

        Task CreatePaiement(Paiement paiement);

        Task UpdatePaiement(Paiement paiement);

        Task DeletePaiement(int id);
    }
}
