using Microsoft.AspNetCore.Mvc;
using Sem2_Large_Systems.Services;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Controllers
{
    public class JobController : Controller
    {
        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        // View all jobs
        [HttpGet]
        public async Task<IActionResult> Index(int? warehouseId)
        {
            var jobs = await _jobService.GetAllJobs();

            // If warehouseId is specified, filter the jobs by warehouse
            if (warehouseId.HasValue)
            {
                jobs = jobs.Where(j => j.WarehouseId == warehouseId.Value).ToList();
                ViewBag.SelectedWarehouseId = warehouseId.Value;  // Set ViewBag for the selected warehouse
            }

            return View(jobs);
        }


        // View job details by ID
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
    }
}
