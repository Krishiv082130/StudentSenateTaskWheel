using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Senate_Task_Wheel.Models;

namespace Student_Senate_Task_Wheel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<DutyTask> DutyTasks { get; set; }
        public DbSet<RotationAssignment> RotationAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RotationAssignment>()
                .HasOne(r => r.Member)
                .WithMany(m => m.RotationAssignments)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RotationAssignment>()
                .HasOne(r => r.DutyTask)
                .WithMany(d => d.RotationAssignments)
                .HasForeignKey(r => r.DutyTaskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
