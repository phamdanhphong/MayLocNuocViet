using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("AuditTrailLogs")]
    public class AuditTrailLog
    {

        public AuditTrailLog() { }

        

        /// <summary>
        /// AuditTrailLog
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="TableName"></param>
        /// <param name="NewValue"></param>
        /// <param name="UserId"></param>
        /// <param name="ChangeTime"></param>
        public AuditTrailLog(
            string Action, string TableName,
            string NewValue, string OldValue, string UserId, DateTime ChangeTime)
        {
            this.Action = Action;
            this.TableName = TableName;
            this.NewValue = NewValue;
            this.OldValue = OldValue;
            this.UserId = UserId;
            this.ChangeTime = ChangeTime;
        }

        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Action { get; set; }

        [StringLength(255)]
        public string TableName { get; set; }

        [StringLength(100)]
        public string RecordId { get; set; }

        [StringLength(3000)]
        public string OldValue { get; set; }

        [StringLength(3000)]
        public string NewValue { set; get; }

        public string UserId { set; get; }

        public DateTime ChangeTime{ get; set; }
    }
}
