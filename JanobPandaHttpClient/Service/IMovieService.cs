using JanobPandaHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanobPandaHttpClient.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(long id);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<Movie> SetImageAsync(long id, string imageUrl);
        Task GetAndSaveImageAsync(long id, string filePath);
        Task<Movie> UpdateMovieAsync(long id, Movie movie);
        Task<bool> DeleteMovieAsync(long id);
    }
}
