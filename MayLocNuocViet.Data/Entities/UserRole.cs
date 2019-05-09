using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<Guid>
    {
        [StringLength(100)]
        public string CreatedBy { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set ; get; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { set; get; }

        public string Discriminator { set; get; }
    }    
}
