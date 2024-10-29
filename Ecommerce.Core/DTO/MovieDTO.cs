using Ecommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public decimal Rank { get; set; }
        public string? Image { get; set; }

        public int GenreId { get; set; }
        public string? genre_Name { get; set; }


    }
}
