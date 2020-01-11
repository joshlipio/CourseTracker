/*
  Author:    Joshua Lipio
  Date:      10/18/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4540_PS2.Data;
using CS4540_PS2.Models;
using Microsoft.AspNetCore.Authorization;

namespace CS4540_PS2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LearningOutcomesController : Controller
    {
        private readonly SchoolContext _context;

        public LearningOutcomesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: LearningOutcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LearningOutcomes.ToListAsync());
        }

        // GET: LearningOutcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (learningOutcome == null)
            {
                return NotFound();
            }

            return View(learningOutcome);
        }

        [HttpPost]
        public JsonResult ChangeNote(string note, int noteID)
        {
            var dbNote = _context.LONotes.Find(noteID);
            dbNote.Note = note;
            _context.SaveChanges();

            return Json(new { success = true, note = note, id = noteID });
        }

        // GET: LearningOutcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningOutcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,courseinstanceID")] LearningOutcome learningOutcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningOutcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningOutcome);
        }

        // GET: LearningOutcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes.FindAsync(id);
            if (learningOutcome == null)
            {
                return NotFound();
            }
            return View(learningOutcome);
        }

        // POST: LearningOutcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,courseinstanceID")] LearningOutcome learningOutcome)
        {
            if (id != learningOutcome.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningOutcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningOutcomeExists(learningOutcome.ID))
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
            return View(learningOutcome);
        }

        // GET: LearningOutcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (learningOutcome == null)
            {
                return NotFound();
            }

            return View(learningOutcome);
        }

        // POST: LearningOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningOutcome = await _context.LearningOutcomes.FindAsync(id);
            _context.LearningOutcomes.Remove(learningOutcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningOutcomeExists(int id)
        {
            return _context.LearningOutcomes.Any(e => e.ID == id);
        }
    }
}
