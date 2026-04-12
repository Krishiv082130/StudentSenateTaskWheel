using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Student_Senate_Task_Wheel.Pages.DutyTasks
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public DeleteModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DutyTask DutyTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutytask = await _context.DutyTasks.FirstOrDefaultAsync(m => m.DutyTaskId == id);

            if (dutytask == null)
            {
                return NotFound();
            }
            else
            {
                DutyTask = dutytask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutytask = await _context.DutyTasks.FindAsync(id);
            if (dutytask != null)
            {
                DutyTask = dutytask;
                _context.DutyTasks.Remove(DutyTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
