using System.ComponentModel.DataAnnotations;

namespace Student_Senate_Task_Wheel.Models
{
    public class Role
    {
            public int RoleId { get; set; }

            [Required]
            public string RoleName { get; set; }

            public ICollection<Member> Members { get; set; }
        }
}
