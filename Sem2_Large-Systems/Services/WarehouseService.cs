using DataAccess;
using Sem2_Large_Systems.IServices;
using Sem2_Large_Systems.Models;

namespace Sem2_Large_Systems.Services {
    public class WarehouseService : IWarehouseService{

        private readonly IDataAccess _dataAccess;

        public WarehouseService(IDataAccess dataAccess) {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<Warehouse?> GetWarehouseById(int id) {
            var sql = @"SELECT * FROM Warehouses WHERE WarehouseID = @Id";
            var parameters = new { Id = id };
            return await _dataAccess.GetById<Warehouse>(sql, parameters);
        }

        public async Task<List<Warehouse>> GetAllWarehouses() {
            var sql = @"SELECT * FROM Warehouses";
            return await _dataAccess.GetAll<Warehouse>(sql);
        }

        public async Task AddWarehouse(Warehouse warehouse) {
            var sql = @"INSERT INTO Warehouses (Capacity, CurrentLoad, ChemicalClassRestrictions)
                        VALUES (@Capacity, @CurrentLoad, @ChemicalClassRestrictions)";
            await _dataAccess.Insert(sql, warehouse);
        }

        public async Task UpdateWarehouse(Warehouse warehouse) {
            var sql = @"UPDATE Warehouses
                        SET Capacity = @Capacity, CurrentLoad = @CurrentLoad, ChemicalClassRestrictions = @ChemicalClassRestrictions
                        WHERE WarehouseID = @WarehouseID";
            await _dataAccess.Update(sql, warehouse);
        }

        public async Task DeleteWarehouse(int id) {
            var sql = @"DELETE FROM Warehouses WHERE WarehouseID = @Id";
            var parameters = new { Id = id };
            await _dataAccess.Delete(sql, parameters);
        }
    }
}
