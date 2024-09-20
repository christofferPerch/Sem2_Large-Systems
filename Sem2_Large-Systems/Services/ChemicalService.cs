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
            var sql = @"SELECT * FROM Chemical WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Chemical>(sql, parameters);
        }

        public async Task<List<Chemical>> GetAllChemicals()
        {
            var sql = @"SELECT * FROM Chemical";
            return await _dataAccess.GetAll<Chemical>(sql);
        }

        public async Task AddChemical(Chemical chemical)
        {
            var sql = @"INSERT INTO Chemical (ChemicalName, Quantity, WarehouseId, Class)
                        VALUES (@ChemicalName, @Quantity, @WarehouseId, @Class)";
            var parameters = new
            {
                chemical.ChemicalName,
                chemical.Quantity,
                chemical.WarehouseId,
                Class = (int)chemical.Class  // Using enum as an integer
            };
            await _dataAccess.Insert(sql, parameters);
        }

        public async Task UpdateChemical(Chemical chemical)
        {
            var sql = @"UPDATE Chemical
                        SET ChemicalName = @ChemicalName, Quantity = @Quantity, 
                            WarehouseId = @WarehouseId, Class = @Class
                        WHERE Id = @Id";
            var parameters = new
            {
                chemical.ChemicalName,
                chemical.Quantity,
                chemical.WarehouseId,
                Class = (int)chemical.Class,  // Using enum as an integer
                chemical.Id
            };
            await _dataAccess.Update(sql, parameters);
        }

        public async Task DeleteChemical(int id)
        {
            var sql = @"DELETE FROM Chemical WHERE Id = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
