using   Fsoft.SKU.CoreApp.Utilities.Constants;
using System;

namespace  Fsoft.SKU.CoreApp.Services.Providers
{
    public class FileInfoModel
    {
        public string FileName { get; set; }

        public string Folder { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        private string ContentType { get; set; }

        public long Size { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public CommonConstants.DocumentType DocumentType { get; set; }

        public string DocumentId { get; set; }

        public string FullName { get; set; }
    }
}
