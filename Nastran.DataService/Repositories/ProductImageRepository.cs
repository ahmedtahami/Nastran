using Nastran.DataService.DbContext;

namespace Nastran.DataService.Repositories
{
    public class ProductImageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductImageRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public List<DbEntities.ProductImage> GetAll()
        {
            try
            {
                return this._dbContext.ProductImages.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.ProductImage? Get(long id)
        {
            try
            {
                return _dbContext.ProductImages.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.ProductImage Add(DbEntities.ProductImage entity)
        {
            try
            {
                var result = _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.ProductImage Update(DbEntities.ProductImage entity)
        {
            try
            {
                var result = _dbContext.Update(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.ProductImage Delete(DbEntities.ProductImage entity)
        {
            try
            {
                var result = _dbContext.Remove(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
