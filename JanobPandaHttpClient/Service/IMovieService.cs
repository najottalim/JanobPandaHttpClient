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
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(long id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> SetImage(long id, string imageUrl);
        Task<byte[]> GetImage(long id);
    }
}
