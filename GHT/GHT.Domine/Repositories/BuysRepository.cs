using GHT.Core.Entities;
using GHT.Domine.Data;
using GHT.Domine.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Domine.Repositories
{
   public class BuysRepository : IBuysRepository
    {
        private readonly GHTContext dbc;
        public BuysRepository(GHTContext context)
        {
            dbc = context;
        }

        public async Task<IEnumerable<Buys>> GetBuys()
        {
            var Buyss = await dbc.Buys.Include(x=> x.Items).ToListAsync();
            return Buyss;
        }

        public async Task<Buys> GetBuy(int id)
        {
            var Buys = await dbc.Buys.Include(x => x.Items).FirstOrDefaultAsync(x => x.id == id);
            return Buys;
        }

        public async Task InsertBuy(Buys model)
        {
            dbc.Buys.Add(model);
            await dbc.SaveChangesAsync();

        }
        public async Task<bool> UpdateBuys(Buys model)
        {
            var Buys = await GetBuy(model.id);
            Buys.idItem = model.idItem;
            Buys.quantity = model.quantity;
            Buys.dateBuy = model.dateBuy;
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteBuys(int id)
        {
            var Buys = await GetBuy(id);
            dbc.Buys.Remove(Buys);
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }
    }
}
