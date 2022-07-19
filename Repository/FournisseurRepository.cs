using G_Stock_Vente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class FournisseurRepository : IFournisseurRepository
    {
        private readonly AppDbContext _bd;
        public FournisseurRepository(AppDbContext context)
        {
            _bd = context;
        }

        public async Task<IEnumerable<Fournisseur>> AllActifFsseurs()
        {
            return await _bd.fournisseurs.Where(f => f.statutFsseur == true).ToListAsync();
        }

        public async Task<IEnumerable<Fournisseur>> AllFsseurs()
        {
            return await _bd.fournisseurs.ToListAsync();
        }

        public async Task CreateFsseur(Fournisseur fsseur)
        {
           
            _bd.fournisseurs.Add(fsseur);
            await _bd.SaveChangesAsync();
        }

        public async Task DeleteFsseur(int id)
        {
            var f = _bd.fournisseurs.Find(id);
            _bd.fournisseurs.Remove(f);
            await _bd.SaveChangesAsync();
        }

        public async Task<Fournisseur> GetFsseur(int id)
        {
           return await _bd.fournisseurs.FindAsync(id);
        }

        public async Task UpdateFsseur(Fournisseur fsseur)
        {
            _bd.fournisseurs.Update(fsseur);
            await _bd.SaveChangesAsync();
        }
    }
}
