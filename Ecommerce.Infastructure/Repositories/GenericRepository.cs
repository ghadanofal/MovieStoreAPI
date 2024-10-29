using Ecommerce.Core.IRepositories;
using Ecommerce.Core.Models;
using Ecommerce.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            
    }

        public async Task Create(T request)
        {
           await  context.Set<T>().AddAsync(request);
        }

        /*public async Task Delete(int id)
        {
            var entity = await GetById(id); // Fetch the entity
            if (entity != null)
            {
                dbSet.Remove(entity); // Remove the entity
            }
            else
            {
                throw new InvalidOperationException("Entity not found");
            }
        }*/
        public async Task Delete(int id)
        {
            var entity = await GetById(id); // Await to ensure entity is fetched
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found"); // Handle this gracefully
            }
            context.Set<T>().Remove(entity); // This should be fine if entity is valid
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, int page_Size =2, int page_Number=1, string? includeProperity = null)
        {
            //if(typeof(T)== typeof(Product))
            //{
            //    var query = await context.Products.Include(x => x.categories).ToListAsync();
            //     return (IEnumerable<T>)query;
            //}

            IQueryable<T> query = context.Set<T>(); /// Product  where().Include

            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperity != null)
            {
                
                foreach (var prority in includeProperity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperity);

                }
            }
            if(page_Size > 0)
            {
                if(page_Size > 4)
                {
                    page_Size = 4;
                }
            }
            query = query.Skip(page_Size * (page_Number - 1)).Take(page_Size);
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var model = await context.Set<T>().FindAsync(id);
            return model;
        }

        public void update(T request)
        {
            context.Update(request);
        }

       
    }
}
