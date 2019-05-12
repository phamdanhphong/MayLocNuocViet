using MLT.MayLocNuocViet.Infrastructure.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLT.MayLocNuocViet.Data.Entities
{
    [Table("Position")]
    public class Position : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderBy { get; set; }
    }
}
