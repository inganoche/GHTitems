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
    public class BuysService : IBuysService
    {

        private readonly IBuysRepository BuysRepository;
        private readonly IItemsRepository itemsRepository;

        public BuysService(IBuysRepository _BuysRepository,IItemsRepository _itemsRepository )
        {
            BuysRepository = _BuysRepository;
            itemsRepository = _itemsRepository;

        }
        public async Task<Buys> GetBuys(int id)
        {
            try
            {
                return await BuysRepository.GetBuy(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Buys>> GetBuyss()
        {
            try
            {
                return await BuysRepository.GetBuys();


            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task InsertBuys(Buys model)
        {
            try
            {
                var items = await itemsRepository.GetItem(model.idItem);

                //Validation
                if (items == null)
                {
                    throw new GlobalException("El item no está registrado");
                }

                if (model.quantity  > items.residue )
                {
                    throw new GlobalException("No es posible registrar compra, la cantidad es mayor al item.");
                }


                await BuysRepository.InsertBuy(model);

            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }
        public async Task<bool> UpdateBuys(Buys model)
        {
            try
            {

                return await BuysRepository.UpdateBuys(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<bool> DeleteBuys(int id)
        {
            try
            {
                return await BuysRepository.DeleteBuys(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
    }
}
