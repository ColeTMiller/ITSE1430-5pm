//Cole Miller
//MovieViewModels
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMovies.Models
{
    public class MovieViewModels
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Episode { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Time { get; set; }

        public bool Own { get; set; }
    }
}