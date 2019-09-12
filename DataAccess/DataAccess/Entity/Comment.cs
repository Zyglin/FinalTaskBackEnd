using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(160)]
        public string Description { get; set; }

        public Film Film { get; set; }
        public string FilmId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
