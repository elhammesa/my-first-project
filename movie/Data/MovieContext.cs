﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movie.Models;

namespace movie.Data
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            :base( options)
        { }
        public DbSet<Movie> Movie { get; set; }
    }
}
