using System;
using System.Threading.Tasks;
using Dapper;
using ImageUploader.Data.Interfaces;
using ImageUploader.Models;

namespace ImageUploader.Data.Repositories
{
  public class UploadRepository : IUploadRepository
  {
    private readonly DbContext _db;
    public UploadRepository(DbContext db)
    {
        _db = db;
    }
    public async Task SaveUploadAudit(UploadAuditDataModel model)
    {
        using (var connection = _db.CreateConnection()) 
        {
            await connection.ExecuteAsync(@"
            INSERT INTO UploadAudit
                (Id, FileName, UploadDateTime)
            VALUES
                (@Id, @FileName, @UploadDateTime)", model)
            .ConfigureAwait(false);
        }
    }
  }
}