using   Fsoft.SKU.CoreApp.Utilities.Constants;
using System;

namespace  Fsoft.SKU.CoreApp.Services.Providers
{
    public class FolderInfoModel
    {
        public string FolderName { get; set; }

        public FolderInfoModel Parent { get; set; }

        public string Path { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public CommonConstants.DocumentType DocumentType { get; set; }

        public string DocumentId { get; set; }
    }
}
