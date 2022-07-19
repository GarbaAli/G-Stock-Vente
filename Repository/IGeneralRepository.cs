using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
   public interface IGeneralRepository
    {
        General GetInfos(int id);
        string GetNomApp();
        string GetDevise();
        int GetDayAlerte();
        void InitialInfos(General general);
    }
}
