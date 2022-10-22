using System;
using System.Threading.Tasks;
using ImageUploader.Models;

namespace ImageUploader.Data.Interfaces
{
    public interface IUploadRepository
    {
         Task SaveUploadAudit(UploadAuditDataModel model);
    }
}