using Sem2_Large_Systems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.IServices
{
    public interface ITicketService
    {
        Task<Ticket?> GetTicketById(int id);
        Task<List<Ticket>> GetAllTickets();
        Task <int> AddTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(int id);
    }
}
