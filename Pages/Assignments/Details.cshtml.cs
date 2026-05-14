using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;

namespace Student_Senate_Task_Wheel.Pages.Assignments
{
    public class DetailsModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public DetailsModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RotationAssignment RotationAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotationassignment = await _context.RotationAssignments.FirstOrDefaultAsync(m => m.RotationAssignmentId == id);
            if (rotationassignment == null)
            {
                return NotFound();
            }
            else
            {
                RotationAssignment = rotationassignment;
            }
            return Page();
        }
    }
}
