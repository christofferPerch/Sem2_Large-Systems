using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var sql = @"SELECT * FROM Jobs WHERE JobID = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Job>(sql, parameters);
        }

        public async Task<List<Job>> GetAllJobs()
        {
            var sql = @"SELECT * FROM Jobs";
            return await _dataAccess.GetAll<Job>(sql);
        }

        public async Task AddJob(Job job)
        {
            var sql = @"INSERT INTO Jobs (TicketID, StorageLocation, JobType, Status)
                        VALUES (@TicketID, @StorageLocation, @JobType, @Status)";
            await _dataAccess.Insert(sql, job);
        }

        public async Task UpdateJob(Job job)
        {
            var sql = @"UPDATE Jobs
                        SET TicketID = @TicketID, StorageLocation = @StorageLocation, JobType = @JobType, Status = @Status
                        WHERE JobID = @JobID";
            await _dataAccess.Update(sql, job);
        }

        public async Task DeleteJob(int id)
        {
            var sql = @"DELETE FROM Jobs WHERE JobID = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
