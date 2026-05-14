using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;

namespace Student_Senate_Task_Wheel.Pages.Organizations
{
    public class DetailsModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public DetailsModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Organization Organization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FirstOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }
            else
            {
                Organization = organization;
            }
            return Page();
        }
    }
}
