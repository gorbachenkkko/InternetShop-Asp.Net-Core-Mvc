using InternetShop.DAL.Interfaces;
using InternetShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using InternetShop.Domain.Enum;
namespace InternetShop.DAL.Repositories
{
    public class ClothesRepository : IBaseRepository<Clothes>
    {
        private readonly ApplicationDbContext _db;
        public ClothesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Clothes entity)
        {
            _db.Clothes.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Clothes entity)
        {
            _db.Clothes.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Clothes> Get(int id)
        {
            return await _db.Clothes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<Clothes> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Clothes> GetByName(string name)
        {
            return await _db.Clothes.FirstOrDefaultAsync(c => c.Name == name);
        }

        public IQueryable<Clothes> Select()
        {
            return _db.Clothes;
        }

        public async Task<Clothes> Update(Clothes entity)
        {
            _db.Clothes.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        
    }
}
