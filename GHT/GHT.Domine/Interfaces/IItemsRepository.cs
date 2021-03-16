using GHT.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHT.Domine.Interface
{
   public interface IItemsRepository
    {
        Task<bool> DeleteItems(int id);
        Task<Items> GetItem(int id);
        Task<IEnumerable<Items>> GetItems();
        Task InsertItem(Items model);
        Task<bool> UpdateItems(Items model);
    }
}