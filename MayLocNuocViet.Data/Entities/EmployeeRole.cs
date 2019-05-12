using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MLT.MayLocNuocViet.Data.Entities
{
    [Table("EmployeeRole")]
    public class EmployeeRole : IdentityUserRole<Guid>
    {
       
    }
}
