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
    public class ItemsRepository : IItemsRepository
    {
        private readonly GHTContext dbc;
        public ItemsRepository(GHTContext context)
        {
            dbc = context;
        }

        public async Task<IEnumerable<Items>> GetItems()
        {
            var Itemss = await dbc.Items.ToListAsync();
            return Itemss;
        }

        public async Task<Items> GetItem(int id)
        {
            var Items = await dbc.Items.FirstOrDefaultAsync(x => x.id == id);
            return Items;
        }

        public async Task InsertItem(Items model)
        {
            dbc.Items.Add(model);
            await dbc.SaveChangesAsync();

        }
        public async Task<bool> UpdateItems(Items model)
        {
            var Items = await GetItem(model.id);
            Items.nameItems = model.nameItems;
            Items.unitValue = model.unitValue;
            Items.residue = model.residue;
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteItems(int id)
        {
            var Items = await GetItem(id);
            dbc.Items.Remove(Items);
            int rows = await dbc.SaveChangesAsync();

            return rows > 0;
        }
    }
}
