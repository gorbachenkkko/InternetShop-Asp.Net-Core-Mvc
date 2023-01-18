using InternetShop.DAL.Interfaces;
using InternetShop.Domain.Entity;

namespace InternetShop.DAL.Repositories
{
    public class BasketRepository : IBaseRepository<Basket>
    {
        private readonly ApplicationDbContext _db;

        public BasketRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Basket entity)
        {
            await _db.Baskets.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public void AddInBasket(User user, Clothes clothes)
        {
            _db.Baskets.Add(new Basket() { UserName = user.Name, ClothesId = clothes.Id });
            _db.SaveChanges();
        }
        
        public async Task Delete(Basket entity)
        {
            _db.Baskets.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Basket> Select()
        {
            return _db.Baskets;
        }

        public Task<Basket> Update(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
