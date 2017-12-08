using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Web.Models
{
    public static class MovieExtensions
    {
        public static IEnumerable<MovieViewModel> ToModel (this IEnumerable<Titles> source)
        {
            foreach (var item in source)
                yield return item.ToModel(); 
        }

        public static MovieViewModel ToModel (this Titles source)
        {
            return new MovieViewModel()
            {
                Id = source.Id,
                Title = source.Title,
                Episode = source.Episode,
                Time = source.Time,
                Own = source.Own
            };
        }

        public static Titles ToDomain(this MovieViewModel source)
        {
            return new Titles()
            {
                Id = source.Id,
                Title= source.Title, 
                Episode = source.Episode,
                Time = source.Time,
                Own = source.Own
            };
        } 

    }
}