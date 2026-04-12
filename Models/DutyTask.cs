using System.ComponentModel.DataAnnotations;

namespace Student_Senate_Task_Wheel.Models
{
    public class DutyTask
    {
        public int DutyTaskId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Frequency { get; set; }

        public bool IsActive { get; set; }

        public ICollection<RotationAssignment> RotationAssignments { get; set; }
    }
}
