using Nastran.DataService.DbContext;

namespace Nastran.DataService.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public List<DbEntities.Category> GetAll()
        {
            try
            {
                return this._dbContext.Categories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.Category? Get(long id)
        {
            try
            {
                return _dbContext.Categories.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.Category Add(DbEntities.Category entity)
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
        public DbEntities.Category Update(DbEntities.Category entity)
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
        public DbEntities.Category Delete(DbEntities.Category entity)
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
