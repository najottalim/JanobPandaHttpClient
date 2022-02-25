using JanobPandaHttpClient.Models;
using JanobPandaHttpClient.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JanobPandaHttpClient
{
    internal class Program
    {
        private static IMovieService _movieService = new MovieService();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Posting...");
            var movie = await _movieService.CreateMovie(new Movie
            {
                Title = "Muzlik davri 6",
                Description = "Grafikasi zor chiqib bu safar",
                Image = "linkda endi",
                Author = new Author
                {
                    FirstName = "Abbos",
                    LastName = "Haydarov"
                }
            });

            Console.WriteLine(movie.Title);
        }
    }
}
