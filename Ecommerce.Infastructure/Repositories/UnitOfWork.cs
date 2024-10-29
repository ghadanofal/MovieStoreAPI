using Ecommerce.Core.IRepositories;
using Ecommerce.Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly IMoviesRepository moviesRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            movieRepository = new MovieRepositories(context);
            genreRepository = new GenreRepository(context);
            orderRepository = new OrderRepository(context);
        }
        public IMoviesRepository movieRepository { get ; set ; }
        public IGenreRepository genreRepository { get; set; }
        public IOrderRepository orderRepository { get; set; }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
