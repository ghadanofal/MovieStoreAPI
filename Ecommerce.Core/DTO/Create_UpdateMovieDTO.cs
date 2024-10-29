using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
    public class Create_UpdateMovieDTO
    {


        public string Title { get; set; } = null!;
        public decimal Rate { get; set; }
        public string? Image { get; set; }

        public int GenreId { get; set; }

    }
}
