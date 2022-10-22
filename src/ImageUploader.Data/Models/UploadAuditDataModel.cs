using System;

namespace ImageUploader.Models
{
    public class UploadAuditDataModel
    {
        public Guid Id { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string FileName { get; set; }
    }
}