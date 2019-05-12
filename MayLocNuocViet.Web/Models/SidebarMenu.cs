using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLT.MayLocNuocViet.Web.Models
{
    public class SidebarMenu
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public bool IsActive { get; set; } = false;

        public string Name { get; set; }

        public string IconClassName { get; set; }

        public string URLPath { get; set; }

        public int SortOder { get; set; }
    }
}
