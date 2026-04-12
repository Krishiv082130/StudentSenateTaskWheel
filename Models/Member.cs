using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Student_Senate_Task_Wheel.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsOrgAdmin { get; set; }

        public ICollection<RotationAssignment> RotationAssignments { get; set; }
    }
}
