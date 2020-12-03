using AzureTableStrorageExample.Server.Options;
using AzureTableStrorageExample.Server.Services;
using AzureTableStrorageExample.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTableStrorageExample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AzureTableStorageOptions _options;
        private readonly ITableService _tableService;

        public PeopleController(AzureTableStorageOptions options, ITableService tableService)
        {
            _options = options;
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonEntity person)
        {
            await _tableService.AddPersonAsync(person);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _tableService.GetPeopleAsync();
            return Ok(people);
        }
    }
}
