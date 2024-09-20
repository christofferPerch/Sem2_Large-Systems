using Sem2_Large_Systems.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.IServices
{
    public interface IAuditTrailService
    {
        Task<AuditTrail?> GetAuditTrailById(int id);
        Task<List<AuditTrail>> GetAllAuditTrails();
        Task AddAuditTrail(AuditTrail auditTrail);
        Task UpdateAuditTrail(AuditTrail auditTrail);
        Task DeleteAuditTrail(int id);
    }
}
