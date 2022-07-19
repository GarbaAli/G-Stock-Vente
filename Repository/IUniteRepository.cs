using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
   public interface IUniteRepository
    {
        //Liste des unites
        Task<List<Unite>> GetAllUniteAsync();
        Task<Unite> GetUniteById(int id);
        Task  CreateUniteAsync(Unite unite);
        Task  DeleteUnite(int id);
        Task UpdateUnite(Unite unite);
    }
}
