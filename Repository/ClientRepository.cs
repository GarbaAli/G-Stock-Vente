using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _bd;

        public ClientRepository(AppDbContext context)
        {
            _bd = context;
        }

        public IEnumerable<Client> AllClient()
        {
            return _bd.Clients.ToList();
        }

        public IEnumerable<Client> AllClientActif()
        {
            return _bd.Clients.Where(c => c.statutClt == true).ToList();
        }

        public void CreateClient(Client clt)
        {
            _bd.Clients.Add(clt);
            _bd.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var res = GetClient(id);
            if (res != null)
            {
                _bd.Clients.Remove(res);
                _bd.SaveChanges();
            }
        }

        public Client GetClient(int id)
        {
            return _bd.Clients.FirstOrDefault(c => c.clientId == id);
        }

        public void UpdateClient(Client clt)
        {
            
                _bd.Clients.Update(clt);
                _bd.SaveChanges();

        }
    }
}
