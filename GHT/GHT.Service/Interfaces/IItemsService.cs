using GHT.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHT.Service.Interfaces
{
    public interface IItemsService
    {
        Task<bool> DeleteItems(int id);
        Task<Items> GetItems(int id);
        Task<IEnumerable<Items>> GetItemss();
        Task InsertItems(Items model);
        Task<bool> UpdateItems(Items model);
    }
}