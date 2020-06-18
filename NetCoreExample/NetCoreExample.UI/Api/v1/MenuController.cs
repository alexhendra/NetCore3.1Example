using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreExample.Interfaces.Service;
using NetCoreExample.UI.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreExample.UI.Api.v1
{
    [Route("api/v1/menu")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService MenuService;

        public MenuController(IMenuService menuService)
        {
            MenuService = menuService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Cached(60)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await MenuService.GetAll());
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
