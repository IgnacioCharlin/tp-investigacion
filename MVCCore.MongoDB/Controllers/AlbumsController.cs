using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore.MongoDB.Data;
using MVCCore.MongoDB.Models;
using MVCCore.MongoDB.Repository;

namespace MVCCore.MongoDB.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MVCCoreMongoDBContext _context;

        private IAlbumCollection db = new AlbumCollection();

        public AlbumsController(MVCCoreMongoDBContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            var albums = db.GetAllAlbums();
            return View(albums);
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            try
            {
                var album =  db.getAlmbumById(id);
                return View(album);
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };

                db.InsertAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }  
        }

        private IActionResult redirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = db.getAlmbumById(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    Id = id,    
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };

                db.updateAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidCastException e)
            {
                return View();
            }
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            Album album = db.getAlmbumById(id);
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                db.DeleteAlbum(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool AlbumExists(string id)
        {
            return _context.Album.Any(e => e.Id == id);
        }
    }
}
