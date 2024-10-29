using Ecommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IMoviesRepository: IGenericRepository<Movie>
    {
        public Task<Movie> FilterMovie();

        public Task<IEnumerable<Movie>> GetAllMovieByGenreId(int genre_id);
    }
}
