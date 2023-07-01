using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payroll_Calculator.Models;

namespace Payroll_Calculator.Controllers
{
    public class WorkerController : Controller
    {
        private readonly WorkerContext _context;

        public WorkerController(WorkerContext context)
        {
            _context = context;
        }

        // GET: Worker
        public async Task<IActionResult> Index()
        {
            return View(await _context.PieceworkWorkerModel.ToListAsync());
        }

        // GET: Worker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // GET: Worker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Message,Pay,IsSenior")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceworkWorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceworkWorkerModel);
        }

        // GET: Worker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel.FindAsync(id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }
            return View(pieceworkWorkerModel);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Message,Pay,IsSenior")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (id != pieceworkWorkerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceworkWorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceworkWorkerModelExists(pieceworkWorkerModel.Id))
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
            return View(pieceworkWorkerModel);
        }

        // GET: Worker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PieceworkWorkerModel == null)
            {
                return Problem("Entity set 'WorkerContext.PieceworkWorkerModel'  is null.");
            }
            var pieceworkWorkerModel = await _context.PieceworkWorkerModel.FindAsync(id);
            if (pieceworkWorkerModel != null)
            {
                _context.PieceworkWorkerModel.Remove(pieceworkWorkerModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceworkWorkerModelExists(int id)
        {
            return _context.PieceworkWorkerModel.Any(e => e.Id == id);
        }
    }
}
