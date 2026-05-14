using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Data;
using Student_Senate_Task_Wheel.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Student_Senate_Task_Wheel.Pages
{
    public class ReportsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReportsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MemberCompletion> CompletionRates { get; set; } = new();
        public List<RotationAssignment> PendingTasks { get; set; } = new();
        public List<RoleTaskCount> TaskDistribution { get; set; } = new();

        public void OnGet()
        {
            // 1️⃣ Completion Rate by Role
            CompletionRates = _context.RotationAssignments
                .Include(r => r.Member)
                    .ThenInclude(m => m.Role)
                .GroupBy(r => r.Member!.Role!.RoleName)
                .Select(g => new MemberCompletion
                {
                    Member = g.Key,
                    TotalTasks = g.Count(),
                    CompletedTasks = g.Count(x => x.Status == "Completed")
                })
                .ToList();

            // 2️⃣ Pending Tasks
            PendingTasks = _context.RotationAssignments
                .Include(r => r.Member)
                    .ThenInclude(m => m.Role)
                .Include(r => r.DutyTask)
                .Where(r => r.Status != "Completed")
                .ToList();

            // 3️⃣ Task Distribution by Role
            TaskDistribution = _context.RotationAssignments
                .Include(r => r.Member)
                    .ThenInclude(m => m.Role)
                .GroupBy(r => r.Member!.Role!.RoleName)
                .Select(g => new RoleTaskCount
                {
                    RoleName = g.Key,
                    TaskCount = g.Count()
                })
                .ToList();
        }
    }

    public class MemberCompletion
    {
        public string? Member { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
    }

    public class RoleTaskCount
    {
        public string? RoleName { get; set; }
        public int TaskCount { get; set; }
    }
}