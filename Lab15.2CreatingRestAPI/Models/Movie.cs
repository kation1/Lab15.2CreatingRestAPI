using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace Lab15._2CreatingRestAPI.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string category { get; set; }

        const string server = "Server=6PP7Q13\\SQLEXPRESS;Database=Movies;user id = asdf; password=asdf;";

        public static List<Movie> Read()
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> movies = db.GetAll<Movie>().ToList();
            return movies;
        }

        public static List<Movie> GetAllMovies()
        {
            List<Movie> movies = Read();

            return movies;
        }


        public static List<Movie> ReadByCategory(string category)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> movies = db.Query<Movie>($"select * from Movies where Category LIKE '%{category}%'").AsList();
            return movies;
        }

        public static Movie RandomMovie()
        {

            var random = new Random();
            Movie randMovie;

            List<Movie> movies = GetAllMovies();

            int index = random.Next(movies.Count);
            randMovie = movies[index];


            return randMovie;
        }

        public static Movie RandomByCategory(string category)
        {

            var random = new Random();
            Movie randMovie;

            List<Movie> movies = ReadByCategory(category);

            int index = random.Next(movies.Count);
            randMovie = movies[index];


            return randMovie;
        }

    }

}
