using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Student_Senate_Task_Wheel.Pages.Assignments
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public EditModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RotationAssignment RotationAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotationassignment =  await _context.RotationAssignments.FirstOrDefaultAsync(m => m.RotationAssignmentId == id);
            if (rotationassignment == null)
            {
                return NotFound();
            }
            RotationAssignment = rotationassignment;
           ViewData["DutyTaskId"] = new SelectList(_context.DutyTasks, "DutyTaskId", "Title");
           ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RotationAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotationAssignmentExists(RotationAssignment.RotationAssignmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RotationAssignmentExists(int id)
        {
            return _context.RotationAssignments.Any(e => e.RotationAssignmentId == id);
        }
    }
}
