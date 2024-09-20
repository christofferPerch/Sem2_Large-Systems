using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Services
{
    public class TicketService : ITicketService
    {
        private readonly IDataAccess _dataAccess;

        public TicketService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Ticket?> GetTicketById(int id)
        {
            var sql = @"SELECT * FROM Ticket WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Ticket>(sql, parameters);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var sql = @"
        SELECT t.*, tc.TicketId, tc.ChemicalId, c.ChemicalName, tc.Quantity
        FROM Ticket t
        LEFT JOIN TicketChemicals tc ON t.Id = tc.TicketId
        LEFT JOIN Chemical c ON tc.ChemicalId = c.Id";

            return await _dataAccess.GetAll<Ticket>(sql);
        }


        public async Task<int> AddTicket(Ticket ticket)
        {
            var sql = @"INSERT INTO Ticket (DriverName, Status)
                OUTPUT INSERTED.Id  -- Returns the newly inserted TicketId
                VALUES (@DriverName, @Status)";

            var parameters = new
            {
                ticket.DriverName,
                ticket.Status
            };

            return await _dataAccess.InsertAndGetId<int>(sql, parameters);  
        }

        public async Task AddTicketChemical(TicketChemical ticketChemical)
        {
            var sql = @"INSERT INTO TicketChemicals (TicketId, ChemicalId, Quantity)
                        VALUES (@TicketId, @ChemicalId, @Quantity)";

            var parameters = new
            {
                ticketChemical.TicketId,
                ticketChemical.ChemicalId,
                ticketChemical.Quantity
            };

            await _dataAccess.Insert(sql, parameters);  
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var sql = @"UPDATE Ticket
                        SET DriverName = @DriverName, Status = @Status
                        WHERE Id = @Id";
            var parameters = new
            {
                ticket.DriverName,
                ticket.Status,
                ticket.Id
            };
            await _dataAccess.Update(sql, parameters);
        }

        public async Task DeleteTicket(int id)
        {
            var sql = @"DELETE FROM Ticket WHERE Id = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
