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
using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace CS4540_PS2.Controllers
{
    
    public class CourseInstancesController : Controller
    {
        private readonly SchoolContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CourseInstancesController(SchoolContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CourseInstances
        // Displays all courses, edittable by admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseInstances.ToListAsync());
        }

        // GET: CourseInstances for specified instructor
        // Overview of department
        [Authorize(Roles = "Admin,Chair")]
        public async Task<IActionResult> DepartmentOverview()
        {
            return View(await _context.CourseInstances.ToListAsync());
        }

        // GET: CourseInstances for specified instructor
        // Anyone can look at courses they're teaching
        [Authorize(Roles = "Admin,Chair,Instructor")]
        public async Task<IActionResult> InstructorCourses(string id)
        {
            var instructorID = (await _userManager.FindByEmailAsync(User.Identity.Name)).Id;
            return View(_context.CourseInstances.Where(o => o.ProfessorID == instructorID).ToList());
        }

        // GET: CourseInstances/Details/5
        // C# razor
        [Authorize(Roles = "Admin,Chair,Instructor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.CourseInstances
                .Include(o=>o.LearningOutcomes)
                .ThenInclude(p=>p.Note)
                .Include(o=>o.Note)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstance == null)
            {
                return NotFound();
            }

            var instructorID = (await _userManager.FindByEmailAsync(User.Identity.Name)).Id;

            if (courseInstance.ProfessorID != instructorID && !User.IsInRole("Chair") && !User.IsInRole("Admin"))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            return View(courseInstance);
        }

        [HttpPost]
        public JsonResult ChangeNote(string note, int noteID)
        {
            var dbNote = _context.CourseNotes.Find(noteID);
            dbNote.Note = note;
            _context.SaveChanges();

            return Json( new {success = true, note = note, id = noteID });
        }

        // C# HTML
        public async Task<IActionResult> DetailsString(int? id)
        {
            var courseInstance = await _context.CourseInstances
                .Include(o => o.LearningOutcomes)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (courseInstance == null)
            {
                return NotFound();
            }

            var instructorID = (await _userManager.FindByEmailAsync(User.Identity.Name)).Id;

            if (courseInstance.ProfessorID != instructorID && !User.IsInRole("Chair") && !User.IsInRole("Admin"))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            string htmlString = @"
            <div>
                <div>
                    <p class='display-4 container'>" + courseInstance.Name + "</p>" +
                    "<p>" +
                        "<span class='h2 text-center container'>" + courseInstance.Department + " " + courseInstance.Number + "</span>" +
                        "<span class='h2 float-right'><a href='/Home/Professor'>" + courseInstance.Professor + "</a></span>" +
                    "</p>" +
                "</div>" +
                "<div class='jumbotron container'>" +
                    "<h1 class='display-4 text-center'>Learning Outcomes</h1>" +
                    "<p class='lead'>" +
                        "<div class='align-content-center'>" +
                            "<div class='list-group list-group-horizontal text-center' id='list-tab' role='tablist'>" +
                                    "<a class='list-group-item list-group-item-action active' id='list-overview-list' data-toggle='list' href='#list-overview' role='tab' aria-controls=overview>Overview</a>" +
                                    ConcatenateOutcomeList() +
                            "</div>" +
                        "</div>" +
                    "</p>" +
                    "<div class='tab-content' id='nav-tabContent'>" +
                        "<div class='tab-pane fade show active' id='list-overview' role='tabpanel' aria-labelledby='list-overview-list'>" +
                            "<p class='lead container'>" + courseInstance.Description + "</p>" +
                            "<hr class='my-4'>" +
                            "<h1 class='h2 text-center'>Evaluation Metrics</h1>" +
                            "<table class='table table-striped'>" +
                                "<thead class='text-white bg-danger'>" +
                                    "<tr>" +
                                        "<th scope = 'col'> Date </th>" +
                                        "<th scope = 'col'>Assignment Name</th>" +
                                        "<th scope = 'col'> Example </th>" +
                                    "</tr>" +
                                "</thead>" +
                                "<tbody>" +
                                    ConcatenateAssignments() +
                                "</tbody>" +
                            "</table>" +
                        "</div>" +
                        ConcatenateLearningOutcomes() +
                    "</div>" +
                "</div>" +
            "</div>";

            string ConcatenateOutcomeList()
            {
                string s = "";
                for (int j = 1; j < courseInstance.LearningOutcomes.Count + 1; j++)
                {
                    s += "<a class='list-group-item list-group-item-action' id='list-lo" + j + "-list' data-toggle='list' href='#list-lo" + j + "' role='tab' aria-controls='lo" + j + "'>" + j + "</a>";
                }
                return s;
            }

            string ConcatenateAssignments()
            {
                string s = "";
                for (int j = 1; j < courseInstance.LearningOutcomes.Count + 1; j++)
                {
                    s += "<tr>" +
                            "<th scope = 'row'> 8/28 </th>" +
                            "<td><a href='~/assignment_definition.pdf'>PS" + j + "</a><br/></td>" +
                            "<td><a href = '~/assignment_definition.pdf'> Link </a><br/></td>" +
                        "</tr>";

                    if (j % 2 == 0)
                    {
                        s += "<tr>" +
                                    "<th scope='row'> 9/19 </th>" +
                                    "<td> Exam" + j / 2 + "</td>" +
                                    "<td>Link</td>" +
                                "</tr>";
                    }
                }
                return s;
            }

            string ConcatenateLearningOutcomes()
            {
                string s = "";
                for (int j = 1; j < courseInstance.LearningOutcomes.Count + 1; j++)
                {
                    s += "<div class='tab-pane fade' id='list-lo" + j + "' role='tabpanel' aria-labelledby='list-l" + j + "-list'>" +
                            "<p class='lead'>" + courseInstance.LearningOutcomes.ToList()[j - 1].Description + "</p>" +
                            "<hr class='my-4'>" +
                            "<h1 class='h2 text-center'>Related Evaluation Metrics</h1>" +
                            "<table class='table table-striped'>" +
                                "<thead class='text-white bg-danger'>" +
                                    "<tr>" +
                                        "<th scope = 'col'> Date </th >" +
                                        "<th scope = 'col'> Assignment Name </th>" +
                                        "<th scope = 'col'> Example </th>" +
                                    "</tr>" +
                                "</thead>" +
                                "<tbody>" +
                                    "<tr>" +
                                        "<th scope= 'row'> 8/28 </th>" +
                                        "<td><a href = '~/assignment_definition.pdf'> PS" + j + "</a><br/></td>" +
                                        "<td><a href = '~/assignment_definition.pdf'> Link </a><br/></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<th scope= 'row'> 9/19 </th>" +
                                        "<td > Exam " + j / 2 + "</td>" +
                                        "<td>Link</td>" +
                                    "</tr>" +
                                "</tbody>" +
                            "</table>" +
                        "</div>";
                }
                return s;
            }

            ViewData["htmlString"] = htmlString;
            return View();
        }

        // GET: CourseInstances/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseInstances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Department,Number,Semester,Professor")] CourseInstance courseInstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseInstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseInstance);
        }

        // GET: CourseInstances/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.CourseInstances.FindAsync(id);
            if (courseInstance == null)
            {
                return NotFound();
            }
            return View(courseInstance);
        }

        // POST: CourseInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Department,Number,Semester,Professor")] CourseInstance courseInstance)
        {
            if (id != courseInstance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseInstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseInstanceExists(courseInstance.ID))
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
            return View(courseInstance);
        }

        // GET: CourseInstances/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.CourseInstances
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstance == null)
            {
                return NotFound();
            }

            return View(courseInstance);
        }

        // POST: CourseInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseInstance = await _context.CourseInstances.FindAsync(id);
            _context.CourseInstances.Remove(courseInstance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseInstanceExists(int id)
        {
            return _context.CourseInstances.Any(e => e.ID == id);
        }
    }
}
