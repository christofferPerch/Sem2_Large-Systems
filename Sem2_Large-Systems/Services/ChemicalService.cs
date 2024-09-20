using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Services
{
    public class ChemicalService : IChemicalService
    {
        private readonly IDataAccess _dataAccess;

        public ChemicalService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Chemical?> GetChemicalById(int id)
        {
            var sql = @"SELECT * FROM Chemicals WHERE ChemicalID = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Chemical>(sql, parameters);
        }

        public async Task<List<Chemical>> GetAllChemicals()
        {
            var sql = @"SELECT * FROM Chemicals";
            return await _dataAccess.GetAll<Chemical>(sql);
        }

        public async Task AddChemical(Chemical chemical)
        {
            var sql = @"INSERT INTO Chemicals (Type, Quantity, StorageLocation, Class)
                        VALUES (@Type, @Quantity, @StorageLocation, @Class)";
            await _dataAccess.Insert(sql, chemical);
        }

        public async Task UpdateChemical(Chemical chemical)
        {
            var sql = @"UPDATE Chemicals
                        SET Type = @Type, Quantity = @Quantity, StorageLocation = @StorageLocation, Class = @Class
                        WHERE ChemicalID = @ChemicalID";
            await _dataAccess.Update(sql, chemical);
        }

        public async Task DeleteChemical(int id)
        {
            var sql = @"DELETE FROM Chemicals WHERE ChemicalID = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
