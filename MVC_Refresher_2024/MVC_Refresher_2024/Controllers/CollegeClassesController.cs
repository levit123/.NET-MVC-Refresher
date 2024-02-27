using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Refresher_2024.Data;
using MVC_Refresher_2024.Models;

namespace MVC_Refresher_2024.Controllers
{
    public class CollegeClassesController : Controller
    {
        private readonly MVC_Refresher_2024Context _context;

        public CollegeClassesController(MVC_Refresher_2024Context context)
        {
            _context = context;
        }

        // GET: CollegeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeClass.ToListAsync());
        }

        // GET: CollegeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeClass = await _context.CollegeClass
                .FirstOrDefaultAsync(m => m.CollegeClassID == id);
            if (collegeClass == null)
            {
                return NotFound();
            }

            return View(collegeClass);
        }

        // GET: CollegeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,CollegeClassID,CollegeClassName")] CollegeClass collegeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collegeClass);
        }

        // GET: CollegeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeClass = await _context.CollegeClass.FindAsync(id);
            if (collegeClass == null)
            {
                return NotFound();
            }
            return View(collegeClass);
        }

        // POST: CollegeClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,CollegeClassID,CollegeClassName")] CollegeClass collegeClass)
        {
            if (id != collegeClass.CollegeClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeClassExists(collegeClass.CollegeClassID))
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
            return View(collegeClass);
        }

        // GET: CollegeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeClass = await _context.CollegeClass
                .FirstOrDefaultAsync(m => m.CollegeClassID == id);
            if (collegeClass == null)
            {
                return NotFound();
            }

            return View(collegeClass);
        }

        // POST: CollegeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeClass = await _context.CollegeClass.FindAsync(id);
            if (collegeClass != null)
            {
                _context.CollegeClass.Remove(collegeClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeClassExists(int id)
        {
            return _context.CollegeClass.Any(e => e.CollegeClassID == id);
        }
    }
}
