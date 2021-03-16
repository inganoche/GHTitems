using GHT.Core.Entities;
using GHT.Core.Exceptions;
using GHT.Domine.Interface;
using GHT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Service.Services
{
    public class ItemsService : IItemsService
    {

        private readonly IItemsRepository itemsRepository;

        public ItemsService(IItemsRepository _itemsRepository)
        {
            itemsRepository = _itemsRepository;

        }
        public async Task<Items> GetItems(int id)
        {
            try
            {
                return await itemsRepository.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Items>> GetItemss()
        {
            try
            {
                return await itemsRepository.GetItems();


            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task InsertItems(Items model)
        {
            try
            {


                await itemsRepository.InsertItem(model);

            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }
        public async Task<bool> UpdateItems(Items model)
        {
            try
            {

                return await itemsRepository.UpdateItems(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<bool> DeleteItems(int id)
        {
            try
            {
                return await itemsRepository.DeleteItems(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }

    }
}
