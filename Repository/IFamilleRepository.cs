using G_Stock_Vente.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    interface IFamilleRepository
    {
        Task<IEnumerable<Famille>> AllFamile();
        Task<IEnumerable<Famille>> AllFamilleStatus();

        Task<Famille> GetFamille(int id);

        Task DeleteFamille(int id);

        Task CreateFamille(Famille famille);
        Task UpdateFamille(Famille famille);


    }
}
