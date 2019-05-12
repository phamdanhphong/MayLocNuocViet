using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MLT.MayLocNuocViet.Data.Entities
{
    [Table("Roles")]
    public class Role : IdentityRole<Guid> 
    {
        public Role() : base()
        {

        }
        public Role(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }

    }
}
