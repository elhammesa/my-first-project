﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movie.Data;
using movie.Models;

namespace movie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService db;


        public MoviesController(MovieService movieService)
        {
            db = movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View( db.GetAllMovies());
        }

        // GET: Movies/Details/5
        public  IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = db.GetMoviesById(id);
            ;
                
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.InsertMovies(movie);
               
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = db.GetMoviesById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            

            if (ModelState.IsValid)
            {
                
                   db.UpdateMovie(id,movie);
                   
                
               
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = db.GetMoviesById(id);

            if (movie == null)
            {
                return NotFound();

            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
             db.DeleteMovie(id);
           
            return RedirectToAction(nameof(Index));
        }

      
    }
}
