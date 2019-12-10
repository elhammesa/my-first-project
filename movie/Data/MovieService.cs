using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using movie.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace movie.Data
{
    public class MovieService
    {
        private MongoClient client;
       
        private IMongoDatabase db;
        private readonly IMongoCollection<Movie> movies;

        public MovieService(IConfiguration config)
        {
            client=new MongoClient(config.GetConnectionString("moviedb"));
        
            db = client.GetDatabase("moviedb");
            movies = db.GetCollection<Movie>("movies");
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies.Find(movie=>true).ToList();

        }
        public Movie GetMoviesById( string id)
        {
           
            return movies.Find(p=>p.Id== id).FirstOrDefault();

        }
        public void  InsertMovies(Movie movie)
        {
            movies.InsertOne(movie);
        }

        public void DeleteMovie(string id)
        {
           
            movies.DeleteOne(p=>p.Id== id);
        }

        public void UpdateMovie(string id,Movie movie)
        {
           
            
            movies.ReplaceOne(p=>p.Id==id,movie);
        }


















    }  
}
