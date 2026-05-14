using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Student_Senate_Task_Wheel.Pages.Roles
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public CreateModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Roles.Add(Role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
