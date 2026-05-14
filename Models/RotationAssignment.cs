using System.ComponentModel.DataAnnotations;

namespace Student_Senate_Task_Wheel.Models
{
    public class RotationAssignment
    {
        public int RotationAssignmentId { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public int DutyTaskId { get; set; }
        public DutyTask? DutyTask { get; set; }

        [DataType(DataType.Date)]
        public DateTime WeekStartDate { get; set; }

        public string? Status { get; set; }

        public DateTime? CompletedOn { get; set; }
    }
}
