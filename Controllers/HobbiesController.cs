using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Me.Data;
using Me.Models;

namespace Me.Controllers
{
    public class HobbiesController : Controller
    {
        private readonly MeContext _context;

        public HobbiesController(MeContext context)
        {
            _context = context;
        }

        public string Test()
        {
            return "successfully redirectd";
        }

        // GET: Hobbies 
        public async Task<IActionResult> Index(string wordInDescription, string searchWord)
        {
            if (_context.Hobby == null)
            {
                return Problem("You have no Hobbies (Database is null)");
            }
            IQueryable<string> descriptionQuery = from h in _context.Hobby
                                                   orderby h.Description
                                                   select h.Description;
            var hobbies = from h in _context.Hobby
                        select h; 
            if (!string.IsNullOrEmpty(searchWord))
            {
                hobbies = hobbies.Where(s => s.Description!.Contains(searchWord));
            }

            if (!string.IsNullOrEmpty(wordInDescription))
            {
                hobbies = hobbies.Where(s => s.Description == wordInDescription);
            }

            var hobbyWithDescriptionVM = new HobbyDescriptionViewModel
            {
                WordInDescriptions = new SelectList(await descriptionQuery.Distinct().ToListAsync()),
                Hobbies = await hobbies.ToListAsync()
            };

            return View(hobbyWithDescriptionVM);
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hobby == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hobbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,LastWorkedOn,Rating")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hobby);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hobby == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return View(hobby);
        }

        // POST: Hobbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]  //this attribute specifies that this action can only be performed on POST requests. Actions automatically use the [HttpGet] attribute
        [ValidateAntiForgeryToken]  //this attribute is used to prevent cross site request forgery (XSRF/CRSF) attacks
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LastWorkedOn,Rating")] Hobby hobby)  
        {
            //binds are used to prevent over-posting. Use binds only on properties that are to be modified
            if (id != hobby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbyExists(hobby.Id))
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
            return View(hobby);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hobby == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hobby == null)
            {
                return Problem("Entity set 'MeContext.Hobby'  is null.");
            }
            var hobby = await _context.Hobby.FindAsync(id);
            if (hobby != null)
            {
                _context.Hobby.Remove(hobby);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbyExists(int id)
        {
          return (_context.Hobby?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
