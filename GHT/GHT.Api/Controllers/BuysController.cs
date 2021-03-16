using AutoMapper;
using GHT.Core.DTOs;
using GHT.Core.Entities;
using GHT.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GHT.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : ControllerBase
    {

        private readonly IBuysService BuysService;
        private readonly IMapper mapper;
        public BuysController(IBuysService _BuysService, IMapper _mapper)
        {
            BuysService = _BuysService;
            mapper = _mapper;
        }

        // GET: api/<BuysController>
        [HttpGet]
        public async Task<IActionResult> GetBuys()
        {
            var Buys = await BuysService.GetBuyss();
            var BuysDtoOut = mapper.Map<IEnumerable<BuysDtoOut>>(Buys);
            return Ok(BuysDtoOut);
        }

        // GET api/<BuysController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task<Buys>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBuys(int id)
        {
            var Buys = await BuysService.GetBuys(id);
            var BuysDtoOut = mapper.Map<IEnumerable<BuysDtoOut>>(Buys);
            return Ok(BuysDtoOut);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task<Buys>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post(BuysDto model)
        {
            var buysDto = mapper.Map<Buys>(model);
            await BuysService.InsertBuys(buysDto);
            return Ok(model);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, BuysDto model)
        {
            var Buys = mapper.Map<Buys>(model);
            model.id = id;
            var result = await BuysService.UpdateBuys(Buys);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await BuysService.DeleteBuys(id);
            return Ok(result);
        }
    }
}
