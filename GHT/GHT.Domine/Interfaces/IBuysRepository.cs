using GHT.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHT.Domine.Interface
{
   public interface IBuysRepository
    {
        Task<bool> DeleteBuys(int id);
        Task<IEnumerable<Buys>> GetBuys();
        Task<Buys> GetBuy(int id);
        Task InsertBuy(Buys model);
        Task<bool> UpdateBuys(Buys model);
    }
}