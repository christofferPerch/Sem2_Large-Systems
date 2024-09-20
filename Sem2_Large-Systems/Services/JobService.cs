using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sem2_Large_Systems.ViewModels;

namespace Sem2_Large_Systems.Services
{
    public class JobService : IJobService
    {
        private readonly IDataAccess _dataAccess;

        public JobService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Job?> GetJobById(int id)
        {
            var sql = @"SELECT * FROM Job WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Job>(sql, parameters);
        }

        public async Task<List<JobViewModel>> GetAllJobs()
        {
            var sql = @"
        SELECT j.Id AS JobId, j.Status AS JobStatus,
               t.Id AS TicketId, t.DriverName,
               w.Id AS WarehouseId, w.WarehouseName
        FROM Job j
        LEFT JOIN Ticket t ON j.TicketId = t.Id
        LEFT JOIN Warehouse w ON j.WarehouseId = w.Id";

            var jobs = await _dataAccess.GetAll<JobViewModel>(sql);
            return jobs;
        }



        public async Task AddJob(Job job)
        {
            var sql = @"INSERT INTO Job (TicketId, WarehouseId, Status)
                        VALUES (@TicketId, @WarehouseId, @Status)";
            var parameters = new
            {
                job.TicketId,
                job.WarehouseId,
                job.Status
            };
            await _dataAccess.Insert(sql, parameters);
        }

        public async Task UpdateJob(Job job)
        {
            var sql = @"UPDATE Job
                        SET TicketId = @TicketId, WarehouseId = @WarehouseId, 
                            Status = @Status
                        WHERE Id = @Id";
            var parameters = new
            {
                job.TicketId,
                job.WarehouseId,
                job.Status,
                job.Id
            };
            await _dataAccess.Update(sql, parameters);
        }

        public async Task DeleteJob(int id)
        {
            var sql = @"DELETE FROM Job WHERE Id = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
