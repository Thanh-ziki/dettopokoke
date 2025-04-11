using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMovie.Data;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class CreateController : Controller
    {
        private readonly AppDbContext _context;

        public CreateController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Create
        public async Task<IActionResult> Index()
        {
            return View(await _context.Create.ToListAsync());
        }

        // GET: Create/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var create = await _context.Create
                .FirstOrDefaultAsync(m => m.Id == id);
            if (create == null)
            {
                return NotFound();
            }

            return View(create);
        }

        // GET: Create/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FullName,Address,Email,Phone")] Create create)
        {
            if (ModelState.IsValid)
            {
                _context.Add(create);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(create);
        }

        // GET: Create/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var create = await _context.Create.FindAsync(id);
            if (create == null)
            {
                return NotFound();
            }
            return View(create);
        }

        // POST: Create/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FullName,Address,Email,Phone")] Create create)
        {
            if (id != create.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(create);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreateExists(create.Id))
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
            return View(create);
        }

        // GET: Create/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var create = await _context.Create
                .FirstOrDefaultAsync(m => m.Id == id);
            if (create == null)
            {
                return NotFound();
            }

            return View(create);
        }

        // POST: Create/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var create = await _context.Create.FindAsync(id);
            if (create != null)
            {
                _context.Create.Remove(create);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreateExists(int id)
        {
            return _context.Create.Any(e => e.Id == id);
        }
    }
}
