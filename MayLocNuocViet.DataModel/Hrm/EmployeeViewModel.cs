using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLT.MayLocNuocViet.DataModel.Hrm
{
  
    public class EmployeeViewModel 
    {
        public Guid? Id { set; get; }

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

        public string Email { set; get; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public int Status { get; set; }

        public bool IsLock { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal InsuranceSalary { get; set; }

        public virtual EmployeeViewModel Position { set; get; }



    }
}
