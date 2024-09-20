using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        private readonly IDataAccess _dataAccess;

        public AuditTrailService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<AuditTrail?> GetAuditTrailById(int id)
        {
            var sql = @"SELECT * FROM AuditTrail WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<AuditTrail>(sql, parameters);
        }

        public async Task<List<AuditTrail>> GetAllAuditTrails()
        {
            var sql = @"SELECT * FROM AuditTrail";
            return await _dataAccess.GetAll<AuditTrail>(sql);
        }

        public async Task AddAuditTrail(AuditTrail auditTrail)
        {
            var sql = @"INSERT INTO AuditTrail (JobId, Timestamp, Description)
                        VALUES (@JobId, @Timestamp, @Description)";
            var parameters = new
            {
                auditTrail.JobId,
                auditTrail.Timestamp,
                auditTrail.Description
            };
            await _dataAccess.Insert(sql, parameters);
        }

        public async Task UpdateAuditTrail(AuditTrail auditTrail)
        {
            var sql = @"UPDATE AuditTrail
                        SET JobId = @JobId, Timestamp = @Timestamp, 
                            Description = @Description
                        WHERE Id = @Id";
            var parameters = new
            {
                auditTrail.JobId,
                auditTrail.Timestamp,
                auditTrail.Description,
                auditTrail.Id
            };
            await _dataAccess.Update(sql, parameters);
        }

        public async Task DeleteAuditTrail(int id)
        {
            var sql = @"DELETE FROM AuditTrail WHERE Id = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
