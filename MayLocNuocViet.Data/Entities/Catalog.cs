using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MLT.MayLocNuocViet.Infrastructure.BaseEntities;

namespace MLT.MayLocNuocViet.Data.Entities
{
    [Table("Catalog")]
    public class Catalog :  Entity<int>
    {

        [Required(ErrorMessage = "Catalog Name required", AllowEmptyStrings = false)]
        public string Name { get; set; }
 
        public string Description { get; set; }

        [StringLength(255)]
        public int ParentId { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public string Url { get; set; }
    }
}
