using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("UserInGroups")]
    public class UserInGroup
    {

        public UserInGroup(Guid UserId, int GroupId, string status)
        {
            this.UserId = UserId;
            this.GroupId = GroupId;
            this.Status = status;
        }

        public UserInGroup()
        {

        }

        [Key, Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key, Column(Order = 1)]
        public int GroupId { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

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
