using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoLibraryMVC.Data;
using VideoLibraryMVC.Entities;
using VideoLibraryMVC.Services;
using VideoLibraryMVC.Services.Interfaces;
using VideoLibraryMVC.ViewModels;

namespace VideoLibraryMVC.Controllers
{
    [Authorize]
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IVideoService _videoService;

        public VideosController(ApplicationDbContext context, IVideoService videoService)
        {
            _context = context;
            _videoService = videoService;
        }

        [AllowAnonymous]
        // GET: Videos
        public async Task<IActionResult> Index()
        {
            VideosIndexViewModel model = new();

            var users = _videoService.GetAllUsers();
            
            model.Videos = await _context.Videos.ToListAsync();
            model.Users = users.Select(u => new SelectListItem(u.Salutation, u.Id));

            return model.Videos != null ? 
                        View(model) :
                        Problem("Entity set 'ApplicationDbContext.Videos'  is null.");
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Year,Rating,Stock")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Year,Rating,Stock")] Video video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Videos'  is null.");
            }
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookVideo([Bind("VideoId,UserId")] BookVideoViewModel model)
        {
            var video = await _context.Videos.Include(video => video.Users).FirstOrDefaultAsync(video => video.Id == model.VideoId);
            var user = await _context.Users.Include(user => user.Videos).FirstOrDefaultAsync(user => user.Id == model.UserId);

            if (user != null && video != null)
            {
                user.Videos.Add(video);
                video.Stock--;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool VideoExists(int id)
        {
          return (_context.Videos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
