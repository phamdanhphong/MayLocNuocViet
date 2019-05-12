using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MLT.MayLocNuocViet.Data.Entities
{
    [Table("Employee")]
    public class Employee : IdentityUser<Guid>
    {
        public Employee() { }

        [Required]
        [StringLength(255)]
        public string EmployeeCode { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Gender { get; set; }

        public int PositionId { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public int Status { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { set; get; }

    }
}
