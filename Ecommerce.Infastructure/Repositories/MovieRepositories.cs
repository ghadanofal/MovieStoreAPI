using Ecommerce.Core.IRepositories;
using Ecommerce.Core.Models;
using Ecommerce.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infastructure.Repositories
{
    public class MovieRepositories :  GenericRepository<Movie>, IMoviesRepository
    {
        private readonly ApplicationDbContext context;

        public MovieRepositories(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

       
        public Task<Movie> FilterMovie()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMovieByGenreId(int genre_id)
        {
            //var product = await context.Products
            //    .Include(x => x.categories)
            //    .Where(c => c.CategoryId == cat_id)
            //    .ToListAsync();
            //return product;

            //lazy loading for related data
            var products = await context.Movies
                .Where(c => c.GenreId == genre_id)
                .ToListAsync();
            return products;
        }
    }
}
