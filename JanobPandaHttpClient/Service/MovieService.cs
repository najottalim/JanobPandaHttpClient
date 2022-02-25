using JanobPandaHttpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JanobPandaHttpClient.Service
{
    public class MovieService : IMovieService
    {
        private HttpClient _httpClient;
        public MovieService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            string json = JsonConvert.SerializeObject(movie);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(Constants.MOVIE_POST, content);

            string message = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(message);
        }

        public Task<byte[]> GetImage(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Constants.MOVIE_GET_ALL);

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
        }

        public Task<Movie> SetImage(long id, string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
