using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice_ASP.Models;

namespace practice_ASP.Controllers
{
    public class UnextsController : Controller
    {
        private readonly testdbContext _context;

        public UnextsController(testdbContext context)
        {
            _context = context;
        }

        // GET: Unexts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Unexts.ToListAsync());
        }
        public async Task<IActionResult> Search(string name, string genre)
        {
            //匿名クラスかラムダ式を使っている...？
            if(name!=null && genre != null)
            {
                using (var context = new testdbContext())
                {
                    var unext = context.Unexts
                        .Where(u => u.Name.Contains(name))
                        .Where(u=>u.Genre.Contains(genre))
                        .ToList();
                    return View(unext);
                }
            }
            if (genre != null)
            {
                using (var context = new testdbContext())
                {
                    var unext = context.Unexts
                        .Where(u => u.Genre.Contains(genre))
                        .ToList();
                    return View(unext);
                }
            }else if (name != null)
            {
                using (var context = new testdbContext())
                {
                    var unext = context.Unexts
                        .Where(u => u.Name.Contains(name))
                        .ToList();
                    return View(unext);
                }
            }
            return View(await _context.Unexts.ToListAsync());
        }
        // GET: Unexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unexts == null)
            {
                return NotFound();
            }

            var unext = await _context.Unexts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unext == null)
            {
                return NotFound();
            }

            return View(unext);
        }

        // GET: Unexts/Create
        public IActionResult Create()
        {
            return View();
        }
        

        // POST: Unexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Length,Genre")] Unext unext)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unext);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unext);
        }

        // GET: Unexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unexts == null)
            {
                return NotFound();
            }

            var unext = await _context.Unexts.FindAsync(id);
            if (unext == null)
            {
                return NotFound();
            }
            return View(unext);
        }

        // POST: Unexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Length,Genre")] Unext unext)
        {
            if (id != unext.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnextExists(unext.Id))
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
            return View(unext);
        }

        // GET: Unexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unexts == null)
            {
                return NotFound();
            }

            var unext = await _context.Unexts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unext == null)
            {
                return NotFound();
            }

            return View(unext);
        }

        // POST: Unexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unexts == null)
            {
                return Problem("Entity set 'testdbContext.Unexts'  is null.");
            }
            var unext = await _context.Unexts.FindAsync(id);
            if (unext != null)
            {
                _context.Unexts.Remove(unext);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnextExists(int id)
        {
          return _context.Unexts.Any(e => e.Id == id);
        }
    }
}
