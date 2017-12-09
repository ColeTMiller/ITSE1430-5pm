//Cole Miller
//MovieExtensions
using Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMovies.Models
{
    public static  class MovieExtensions
    {
        public static IEnumerable<MovieViewModels> ToModel (this IEnumerable<Titles> source)
        {
            foreach (var item in source)
                yield return item.ToModel();
        }

        public static MovieViewModels ToModel(this Titles source)
        {
            return new MovieViewModels()
            {
                Id = source.Id,
                Title = source.Title,
                Episode = source.Episode,
                Time = source.Time,
                Own = source.Own
            };
        }

        public static Titles ToDomain(this MovieViewModels source)
        {
            return new Titles()
            {
                Id = source.Id,
                Episode = source.Episode,
                Time = source.Time,
                Own = source.Own,
            }; 
        }
    }
}