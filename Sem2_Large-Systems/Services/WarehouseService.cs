using DataAccess;
using Sem2_Large_Systems.Models;
using Sem2_Large_Systems.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IDataAccess _dataAccess;

        public WarehouseService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Warehouse?> GetWarehouseById(int id)
        {
            var sql = @"SELECT * FROM Warehouse WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Warehouse>(sql, parameters);
        }

        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            var sql = @"SELECT * FROM Warehouse";
            return await _dataAccess.GetAll<Warehouse>(sql);
        }

        public async Task<Warehouse?> CheckWarehouseCapacity(string chemicalType, double quantity)
        {
            ChemicalClass chemicalClass = chemicalType switch
            {
                "A" => ChemicalClass.A,
                "B" => ChemicalClass.B,
                "C" => ChemicalClass.C,
                _ => throw new ArgumentException("Invalid chemical type")
            };

            var sql = @"SELECT * FROM Warehouse
                        WHERE ChemicalClassRestrictions = @ChemicalClass
                        AND Capacity - CurrentLoad >= @Quantity";
            var parameters = new { ChemicalClass = (int)chemicalClass, Quantity = quantity };
            return await _dataAccess.GetById<Warehouse>(sql, parameters);
        }

        public async Task AddWarehouse(Warehouse warehouse)
        {
            var sql = @"INSERT INTO Warehouse (Capacity, CurrentLoad, WarehouseName)
                        VALUES (@Capacity, @CurrentLoad, @WarehouseName)";
            var parameters = new
            {
                warehouse.Capacity,
                warehouse.CurrentLoad,
                warehouse.WarehouseName
            };
            await _dataAccess.Insert(sql, parameters);
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            var sql = @"UPDATE Warehouse
                        SET Capacity = @Capacity, CurrentLoad = @CurrentLoad, 
                            WarehouseName = @WarehouseName
                        WHERE Id = @Id";
            var parameters = new
            {
                warehouse.Capacity,
                warehouse.CurrentLoad,
                warehouse.WarehouseName,
                warehouse.Id
            };
            await _dataAccess.Update(sql, parameters);
        }

        public async Task DeleteWarehouse(int id)
        {
            var sql = @"DELETE FROM Warehouse WHERE Id = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
