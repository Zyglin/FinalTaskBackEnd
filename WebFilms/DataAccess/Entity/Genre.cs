using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        [MaxLength(85)]
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
