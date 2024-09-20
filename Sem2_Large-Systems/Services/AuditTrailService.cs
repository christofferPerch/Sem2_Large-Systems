using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;

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
            var sql = @"SELECT * FROM AuditTrail WHERE LogID = @Id";
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
            var sql = @"INSERT INTO AuditTrail (JobID, Timestamp, Action, ChemicalType, Quantity)
                        VALUES (@JobID, @Timestamp, @Action, @ChemicalType, @Quantity)";
            await _dataAccess.Insert(sql, auditTrail);
        }

        public async Task UpdateAuditTrail(AuditTrail auditTrail)
        {
            var sql = @"UPDATE AuditTrail
                        SET JobID = @JobID, Timestamp = @Timestamp, Action = @Action, 
                            ChemicalType = @ChemicalType, Quantity = @Quantity
                        WHERE LogID = @LogID";
            await _dataAccess.Update(sql, auditTrail);
        }

        public async Task DeleteAuditTrail(int id)
        {
            var sql = @"DELETE FROM AuditTrail WHERE LogID = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
