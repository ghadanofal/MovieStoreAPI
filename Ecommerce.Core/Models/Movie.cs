using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Rating { get; set; }
        public string? Image { get; set; }

        public int GenreId { get; set; }
        public virtual Genre? Genres { get; set; }


        //public virtual ICollection<OrderDetails>? orderDetails { get; set; } = new HashSet<OrderDetails>();
    }
}
