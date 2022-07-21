using G_Stock_Vente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class PaiementRepository : IPaiementRepository
    {
        private readonly AppDbContext _bd;
        public PaiementRepository(AppDbContext context)
        {
            _bd = context;
        }
        public async Task<IEnumerable<Paiement>> AllPaiement()
        {
            return await _bd.paiements.ToListAsync();
        }

        public async Task<IEnumerable<Paiement>> AllPaiementActif()
        {
            return await _bd.paiements.Where(p => p.statutPaiement == true).ToListAsync();
        }

        public async Task CreatePaiement(Paiement paiement)
        {
            _bd.paiements.Add(paiement);
            await _bd.SaveChangesAsync();
        }

        public async Task DeletePaiement(int id)
        {
            var p = _bd.paiements.Find(id);
            _bd.paiements.Remove(p);
            await _bd.SaveChangesAsync();
        }

        public async Task<Paiement> GetPaiement(int id)
        {
            return await _bd.paiements.FirstOrDefaultAsync(p => p.paiementId == id);
        }

        public int nbrePaiement()
        {
            return _bd.paiements.ToList().Count;
        }

        public async Task UpdatePaiement(Paiement paiement)
        {
            _bd.paiements.Update(paiement);
            await _bd.SaveChangesAsync();
        }
    }
}
