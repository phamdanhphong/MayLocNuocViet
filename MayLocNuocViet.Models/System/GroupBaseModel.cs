using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class GroupBaseModel
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public string Description { set; get; }

        public string Status { get; set; }

    }
}
