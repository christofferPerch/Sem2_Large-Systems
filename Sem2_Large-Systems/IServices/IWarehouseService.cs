using Sem2_Large_Systems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.IServices
{
    public interface IWarehouseService
    {
        Task<Warehouse?> GetWarehouseById(int id);
        Task<List<Warehouse>> GetAllWarehouses();
        Task AddWarehouse(Warehouse warehouse);
        Task UpdateWarehouse(Warehouse warehouse);
        Task DeleteWarehouse(int id);
    }
}
