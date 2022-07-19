using G_Stock_Vente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Repository
{
    public class UniteRepository : IUniteRepository
    {
        private readonly AppDbContext _appDbContext;
        public UniteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateUniteAsync(Unite unite)
        {
            unite.Created = DateTime.Now;
            unite.updated = DateTime.Now;
            _appDbContext.Unites.Add(unite);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUnite(int id)
        {
            var unit =  _appDbContext.Unites.Find(id);
            _appDbContext.Unites.Remove(unit);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Unite>> GetAllUniteAsync()
        {
            return await _appDbContext.Unites.ToListAsync();
        }

        public async Task<Unite> GetUniteById(int id)
        {
            return await _appDbContext.Unites.FindAsync(id);
        }

        public async Task UpdateUnite(Unite unite)
        {
            unite.updated = DateTime.Now;
            _appDbContext.Update(unite);
           await _appDbContext.SaveChangesAsync();
        }
    }
}
