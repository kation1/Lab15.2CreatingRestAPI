using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab15._2CreatingRestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._2CreatingRestAPI.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        public List<Movie> ReturnMovieList()
        {
            //List<Movie> movies = DAL.Read();
            List<Movie> movies = Movie.GetAllMovies();

            return movies;
        }

        [HttpGet("Random")]
        public Movie ReturnRandomMovie()
        {
            Movie movie = Movie.RandomMovie();

            return movie;

        }




        [HttpGet("{category}")]
        public List<Movie> ReturnCategory(string category)
        {
            List<Movie> movies = Movie.ReadByCategory(category);
            return movies;
        }

        [HttpGet("{category}/Random")]

        public Movie ReturnRandomFromCategory(string category)
        {
            Movie movie = Movie.RandomByCategory(category);

            return movie;

        }


    }
}
