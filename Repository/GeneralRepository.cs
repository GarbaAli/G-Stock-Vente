using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly AppDbContext _appDbContext;

        public GeneralRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int GetDayAlerte()
        {
            throw new NotImplementedException();
        }

        public string GetDevise()
        {
            throw new NotImplementedException();
        }

        public General GetInfos(int id)
        {
            return _appDbContext.General.SingleOrDefault(g => g.reference == id);
        }

        public string GetNomApp()
        {
            throw new NotImplementedException();
        }

        public void InitialInfos(General general)
        {
            general.dte_creation = DateTime.Now;
            general.last_modification = DateTime.Now;
             _appDbContext.General.Add(general);
            _appDbContext.SaveChanges();
        }
    }
}
