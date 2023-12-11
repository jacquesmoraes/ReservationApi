using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class TableController : BaseApiController
    {

        private readonly ITableRepository _tableRepo;

        public TableController(ITableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            var availableTables = await _tableRepo.GetTablesAsync();
            return Ok(availableTables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tableRepo.GetTableByIdAsync(id);
            return Ok(table);
        }



        
       
    }
}

