using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public virtual int MovieId { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
