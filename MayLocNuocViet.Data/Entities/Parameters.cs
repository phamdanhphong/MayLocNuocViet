using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("Parameters")]
    public class Parameter : IDateTracking
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string ParameterCode { get; set; }

        [StringLength(20)]
        public string ParameterType { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }
    }
}
