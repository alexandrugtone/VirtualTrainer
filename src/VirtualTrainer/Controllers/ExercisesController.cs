using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualTrainer;
using VirtualTrainer.Models.ViewModels;

namespace VirtualTrainer.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly SaliFitnessContext _context;

        public ExercisesController(SaliFitnessContext context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {//same as equipment
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            var exercises = from e in _context.Exercises
                           select e;
            if (!String.IsNullOrEmpty(searchString))
                exercises = exercises.Where(e => e.ExerciseName.Contains(searchString));
            switch (sortOrder)
            {
                case "name_desc":
                    exercises = exercises.OrderByDescending(e => e.ExerciseName);
                    break;
                default:
                    exercises = exercises.OrderBy(e => e.ExerciseName);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<Exercise>.CreateAsync(exercises.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises.Where(e => e.Idexercise == id)
                .FirstOrDefaultAsync();

            if (exercise == null)
            {
                return NotFound();
            }

            var EquipmentIDs = await _context.EquipmentExercises.Where(eq => eq.Idexercise == id)
                .ToArrayAsync();
            if(EquipmentIDs.Length == 0)
                return NotFound($"The selected equipment {id} has no exercises assigned!");

            var IDEquipment = EquipmentIDs.Select(eq => eq.Idequipment)
                .ToArray();
            var Equipments = await _context.Equipment.Where(eq => IDEquipment.Contains(eq.Idequipment))
                .ToArrayAsync();
            var eqe = new ExEq();
            eqe.exercise = exercise;
            eqe.equipment = Equipments;

            return View(eqe);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseName,Sets,Reps,Weight,Instructions")] Exercise exercise)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(exercise);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exerciseToUpdate = await _context.Exercises.FirstOrDefaultAsync(s => s.Idexercise == id);
            if (await TryUpdateModelAsync<Exercise>(
                exerciseToUpdate,
                "",
                s => s.ExerciseName, s => s.Sets, s => s.Reps, s => s.Weight, s => s.Instructions))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(exerciseToUpdate);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Idexercise == id);
            if (exercise == null)
            {
                return NotFound();
            }

            if(saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
            "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
                return RedirectToAction(nameof(Index));

            try
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Idexercise == id);
        }
    }
}
