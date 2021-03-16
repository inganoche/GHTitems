using GHT.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHT.Service.Interfaces
{
   public interface IBuysService
    {
        Task<bool> DeleteBuys(int id);
        Task<Buys> GetBuys(int id);
        Task<IEnumerable<Buys>> GetBuyss();
        Task InsertBuys(Buys model);
        Task<bool> UpdateBuys(Buys model);
    }
}