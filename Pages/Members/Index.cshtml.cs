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

namespace Student_Senate_Task_Wheel.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Student_Senate_Task_Wheel.Data.ApplicationDbContext _context;

        public IndexModel(Student_Senate_Task_Wheel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Members
                .Include(m => m.Organization)
                .Include(m => m.Role)
                .Include(m => m.User).ToListAsync();
        }
    }
}
