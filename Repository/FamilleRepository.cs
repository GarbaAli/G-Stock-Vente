using G_Stock_Vente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class FamilleRepository : IFamilleRepository
    {

        private readonly AppDbContext _bd;

        public FamilleRepository(AppDbContext context)
        {
            _bd = context;
        }

        public async Task<IEnumerable<Famille>> AllFamile()
        {
            return await _bd.familles.ToListAsync();
        }

        public async Task<IEnumerable<Famille>> AllFamilleStatus()
        {
            return await _bd.familles.Where(f => f.statusFamille == true).ToListAsync();
        }

        public async Task CreateFamille(Famille famille)
        {
            _bd.familles.Add(famille);
            await _bd.SaveChangesAsync(); 
        }

        public Task DeleteFamille(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Famille> GetFamille(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFamille(Famille famille)
        {
            throw new NotImplementedException();
        }
    }
}
