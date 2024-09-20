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
            var sql = @"SELECT * FROM Tickets WHERE TicketID = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Ticket>(sql, parameters);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var sql = @"SELECT * FROM Tickets";
            return await _dataAccess.GetAll<Ticket>(sql);
        }

        public async Task<int> AddTicket(Ticket ticket)
        {
            var sql = @"INSERT INTO Tickets (DriverName, ChemicalType, Quantity, ArrivalDate, Status)
                OUTPUT INSERTED.TicketID  -- Return the newly inserted TicketID
                VALUES (@DriverName, @ChemicalType, @Quantity, @ArrivalDate, @Status)";

            return await _dataAccess.InsertAndGetId<int>(sql, ticket);  
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var sql = @"UPDATE Tickets
                        SET DriverName = @DriverName, ChemicalType = @ChemicalType, Quantity = @Quantity, 
                            ArrivalDate = @ArrivalDate, Status = @Status
                        WHERE TicketID = @TicketID";
            await _dataAccess.Update(sql, ticket);
        }

        public async Task DeleteTicket(int id)
        {
            var sql = @"DELETE FROM Tickets WHERE TicketID = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
