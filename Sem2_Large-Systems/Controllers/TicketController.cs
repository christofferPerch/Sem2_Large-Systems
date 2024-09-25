using Microsoft.AspNetCore.Mvc;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.Services;
using Sem2_Large_Systems.ViewModels;
using System;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;
        private readonly JobService _jobService;

        public TicketController(TicketService ticketService, JobService jobService)
        {
            _ticketService = ticketService;
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTickets();
            return View(tickets);  // Ensure you have the Index view
        }

        // Display the form for submitting a new ticket
        [HttpGet]
        public IActionResult SubmitTicket()
        {
            return View(new TicketCreateViewModel());
        }

        // Ticket submission success page
        public IActionResult TicketSuccess()
        {
            return View();
        }

        // Handle ticket submission with multiple chemicals
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitTicket(TicketCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Create and save the Ticket
                var ticket = new Ticket
                {
                    DriverName = model.DriverName,
                    Status = model.Status
                };
                var ticketId = await _ticketService.AddTicket(ticket);

                // Add chemicals to the ticket
                foreach (var chemical in model.Chemicals)
                {
                    var ticketChemical = new TicketChemical
                    {
                        TicketId = ticketId,
                        ChemicalId = chemical.ChemicalId,
                        Quantity = chemical.Quantity  // Ensure this captures the correct decimal value
                    };

                    await _ticketService.AddTicketChemical(ticketChemical);
                }

                // Redirect to the success page
                return RedirectToAction("TicketSuccess");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendJob(int id)
        {
            // Retrieve the ticket by ID
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Update ticket status to "Job Sent"
            ticket.Status = "Job Sent";
            await _ticketService.UpdateTicket(ticket);

            // Create a new job for the ticket
            var job = new Job
            {
                TicketId = ticket.Id,
                WarehouseId = 1,  // Adjust based on your logic for selecting warehouse
                Status = "Created"
            };
            await _jobService.AddJob(job);

            // Redirect back to the ticket index view
            return RedirectToAction("Index");
        }

    }
}
