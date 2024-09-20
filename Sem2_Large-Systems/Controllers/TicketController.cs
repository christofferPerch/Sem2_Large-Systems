using Microsoft.AspNetCore.Mvc;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.Services;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;
        private readonly WarehouseService _warehouseService;
        private readonly JobService _jobService;

        public TicketController(TicketService ticketService, WarehouseService warehouseService, JobService jobService)
        {
            _ticketService = ticketService;
            _warehouseService = warehouseService;
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTickets();
            return View(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var ticketId = await _ticketService.AddTicket(ticket);

                var warehouse = await _warehouseService.CheckWarehouseCapacity(ticket.ChemicalType, ticket.Quantity);

                if (warehouse != null)
                {
                    var job = new Job
                    {
                        TicketID = ticketId,
                        StorageLocation = warehouse.StorageLocation, 
                        JobType = "Store",
                        Status = "Created"
                    };

                    await _jobService.AddJob(job);

                    return RedirectToAction("TicketSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Warehouse does not have enough capacity to store the chemicals.");
                    return View(ticket);
                }
            }

            return View(ticket); 
        }


        public IActionResult TicketSuccess()
        {
            return View();
        }
    }
}
