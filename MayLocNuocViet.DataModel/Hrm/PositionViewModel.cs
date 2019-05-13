using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MLT.MayLocNuocViet.DataModel.Hrm
{
    public class PositionViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderBy { get; set; }

        public virtual ICollection<EmployeeViewModel> Employee { get; set; }
    }
}
