using Nastran.DataService.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastran.DataService.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public List<DbEntities.Product> GetAll() 
        {
            try
            {
                return this._dbContext.Products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.Product? Get(long id)
        {
            try
            {
                return _dbContext.Products.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbEntities.Product Add(DbEntities.Product entity)
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
        public DbEntities.Product Update(DbEntities.Product entity)
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
        public DbEntities.Product Delete(DbEntities.Product entity)
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
