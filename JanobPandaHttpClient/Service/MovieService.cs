using JanobPandaHttpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DotNetUz.Json;

namespace JanobPandaHttpClient.Service
{
    public class MovieService : IMovieService
    {
        private HttpClient _httpClient;
        public MovieService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            string json = JsonConvert.SerializeObject(movie);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _httpClient.PostAsync(Constants.MOVIE_POST, content);

            string message = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(message);
        }

        public async Task GetAndSaveImageAsync(long id, string filePath)
        {
            string api = Constants.MOVIE_GET_IMAGE + $"?movieId={id}";
            File.WriteAllBytes(filePath, await _httpClient.GetByteArrayAsync(api));
        }

        public async Task<Movie> UpdateMovieAsync(long id, Movie movie)
        {
            string api = Constants.MOVIE_UPDATE + $"/{id}";

            string json = JsonConvert.SerializeObject(movie);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(api, content);
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result.JsonAs<Movie>();
            }
            
            return null;
        }

        public async Task<bool> DeleteMovieAsync(long id)
        {
            string api = Constants.MOVIE_DELETE + $"?movieId={id}";
            var response = await _httpClient.DeleteAsync(api);
            
            if(response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<Movie> GetMovieAsync(long id)
        {
            string api = Constants.MOVIE_GET + $"?movieId={id}";
            var response = await _httpClient.GetAsync(api);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result.JsonAs<Movie>();
            }

            return null;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Constants.MOVIE_GET_ALL);

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
        }

        public async Task<Movie> SetImageAsync(long id, string imageUrl)
        {
            string api = Constants.MOVIE_SET_IMAGE + $"?movieId={id}";
            
            var file = await File.ReadAllBytesAsync(imageUrl);
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(file), "file", "image.jpg");
            var response = await _httpClient.PostAsync(api, content);
            
            return (await response.Content.ReadAsStringAsync()).JsonAs<Movie>();
        }
    }
}
