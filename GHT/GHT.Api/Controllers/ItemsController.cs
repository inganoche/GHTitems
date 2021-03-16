using AutoMapper;
using GHT.Core.Entities;
using GHT.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GHT.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ItemsController : ControllerBase
    {

        private readonly IItemsService itemsService;
        private readonly IMapper mapper;
        public ItemsController(IItemsService _itemsService, IMapper _mapper)
        {
            itemsService = _itemsService;
            mapper = _mapper;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetItems()
        {
            var items = await itemsService.GetItemss();
            return Ok(items);
        }
        /// <summary>
        /// Busa un item específico
        /// </summary>
        /// <param name="id">código unico del items</param>
        /// <returns></returns>
        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task<Items>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetItem(int id)
        {
            var Items = await itemsService.GetItems(id);
            return Ok(Items);
        }
        /// <summary>
        /// Inserta un items nuevo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> Post(Items model)
        {
            await itemsService.InsertItems(model);
            return Ok(model);
        }
        /// <summary>
        /// Modfica items
        /// </summary>
        /// <param name="id">código unico del items</param>
        /// <param name="model">moduleo actualizar</param>
        /// <returns></returns>
        [HttpPut]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> Put(int id, Items model)
        {
            var items = mapper.Map<Items>(model);
            model.id = id;
            var result = await itemsService.UpdateItems(model);
            return Ok(result);
        }
        /// <summary>
        /// Elimna un items
        /// </summary>
        /// <param name="id">código unico del items</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await itemsService.DeleteItems(id);
            return Ok(result);
        }
    }
}
