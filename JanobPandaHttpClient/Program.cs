using JanobPandaHttpClient.Models;
using JanobPandaHttpClient.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JanobPandaHttpClient
{
    #pragma warning disable
    internal class Program
    {
        private static IMovieService _movieService = new MovieService();
        static async Task Main(string[] args)
        {
            string fileName = new Random().Next(10000) + ".jpg";
            string filePath = Path.Combine("./././Resourses/Images", fileName);

            string path = "d:/123.png";    
            var movie = await _movieService.SetImageAsync(1, path);
            Console.WriteLine(movie.Title);
        }
    }
}
