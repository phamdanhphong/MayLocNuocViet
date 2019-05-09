using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MLT.MayLocNuocViet.Models.System
{
    public class CatalogViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int  ParentId { get; set; }

        [Required]
        public string Path { get; set; }

        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }
        
        public List<CatalogViewModel> ListCatalog { get; set; }

        public List<CatalogViewModel> Children { get; set; }


        public string Url { get; set; }

        public string Description { get; set; }

        public string ParentName { get; set; }

    }
}
