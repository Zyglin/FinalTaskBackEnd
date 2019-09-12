using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.Entity
{
    public class Film
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(85)]
        public string Name { get; set; }
        
        [Required]
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }

        public string ImageXPath { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
