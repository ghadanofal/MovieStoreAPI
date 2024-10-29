using Ecommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public Task<Genre> FilterGenre();

    }
}
