using Nastran.DataService.DbContext;

namespace Nastran.DataService.Repositories
{
    public class SubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SubCategoryRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public List<DbEntities.SubCategory> GetAll()
        {
            try
            {
                return this._dbContext.SubCategories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.SubCategory? Get(long id)
        {
            try
            {
                return _dbContext.SubCategories.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.SubCategory Add(DbEntities.SubCategory entity)
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
        public DbEntities.SubCategory Update(DbEntities.SubCategory entity)
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
        public DbEntities.SubCategory Delete(DbEntities.SubCategory entity)
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
