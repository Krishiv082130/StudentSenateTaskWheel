using System.ComponentModel.DataAnnotations;

namespace Student_Senate_Task_Wheel.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<DutyTask> DutyTasks { get; set; }
    }
}
