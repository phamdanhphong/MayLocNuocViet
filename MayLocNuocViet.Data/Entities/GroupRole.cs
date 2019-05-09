using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("GroupRoles")]
    public class GroupRole 
    {

        public GroupRole() { }

        public GroupRole(Guid _roleId, int _groupId)
        {
            this.RoleId = _roleId;
            this.GroupId = _groupId;
        }

        [Key, Column(Order = 0)]
        public Guid RoleId { get; set; }

        [Key, Column(Order = 1)]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Role Role { get; set; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

    }    
}
