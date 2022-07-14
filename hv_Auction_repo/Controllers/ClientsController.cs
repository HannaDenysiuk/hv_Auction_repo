using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contracts;

namespace hv_Auction_repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public ClientsController(IRepositoryManager manager)
        {
            _repositoryManager = manager;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _repositoryManager.Client.GetAll(false)); 
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _repositoryManager.Client.GetById(id,false);

            if (client == null)
            {
                return NotFound();
            }

            return  client;
        }

        //GET: api/Client/Lots
        [HttpGet("{id}/lots")]
        public async Task<IActionResult> GetClientLots(int id)
        {
            Client client = await _repositoryManager.Client.GetById(id, false);
            if (client == null)
                return NotFound();

            var lots = await _repositoryManager.Lot.GetAll(false);
            return Ok(lots.Where(lot => lot.UserId == id));
        }


        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            _repositoryManager.Client.CreateUser(client);
            _repositoryManager.Save();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }
        
    }
}
