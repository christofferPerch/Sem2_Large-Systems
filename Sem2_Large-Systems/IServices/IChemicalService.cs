using Sem2_Large_Systems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sem2_Large_Systems.IServices
{
    public interface IChemicalService
    {
        Task<Chemical?> GetChemicalById(int id);
        Task<List<Chemical>> GetAllChemicals();
        Task AddChemical(Chemical chemical);
        Task UpdateChemical(Chemical chemical);
        Task DeleteChemical(int id);
    }
}
