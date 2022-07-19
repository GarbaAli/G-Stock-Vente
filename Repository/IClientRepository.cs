using G_Stock_Vente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
   public interface IClientRepository
    {
        //Liste des tous les clients
        IEnumerable<Client> AllClient();

        //Liste de tous les clts actif
        IEnumerable<Client> AllClientActif();

        // Detail d'un client
        Client GetClient(int id);

        //Supprimmer Client
        void DeleteClient(int id);

        //Ajout d'un client
        void CreateClient(Client clt);

        //Modifier client
        void UpdateClient(Client clt);



    }
}
