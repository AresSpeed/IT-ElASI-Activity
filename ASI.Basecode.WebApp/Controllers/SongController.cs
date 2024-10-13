using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ASI.Basecode.WebApp.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        // Constructor
        public SongController(ISongService songService)
        {
            this._songService = songService;
        }

        // GET: Song/Index
        public ActionResult Index()
        {
            (bool result, IEnumerable<Song> songs) = _songService.GetSongs();
            songs = songs ?? new List<Song>();
            return View(songs);
        }

        // GET: Song/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public IActionResult Create(Song song)
        {
            try
            {
                _songService.AddSong(song);
                return RedirectToAction("Index", "Song");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
            }
            return View();
        }

        // GET: Song/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            (bool result, IEnumerable<Song> songs) = _songService.GetSongs();
            var song = songs.FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Song/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (string.IsNullOrEmpty(song.Title) || string.IsNullOrEmpty(song.Artist) || song.ReleaseDate == DateTime.MinValue)
            {
                ModelState.AddModelError(string.Empty, "All fields (Title, Artist, Release Date) must be filled.");
                return View(song);
            }

            _songService.UpdateSong(song);
            return RedirectToAction("Index");
        }

        // GET: Song/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            (bool result, IEnumerable<Song> songs) = _songService.GetSongs();
            var song = songs.FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Song/DeleteConfirmed/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(string id)
        {
            _songService.DeleteSong(id);
            return RedirectToAction("Index");
        }
    }
}

