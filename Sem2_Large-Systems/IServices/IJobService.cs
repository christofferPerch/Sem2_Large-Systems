using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.IServices
{
    public interface IJobService
    {
        Task<Job?> GetJobById(int id);
        Task<List<JobViewModel>> GetAllJobs();
        Task AddJob(Job job);
        Task UpdateJob(Job job);
        Task DeleteJob(int id);
    }
}
