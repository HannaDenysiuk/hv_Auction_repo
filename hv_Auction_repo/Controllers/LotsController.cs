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
    public class LotsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public LotsController(IRepositoryManager manager)
        {
            _repositoryManager = manager;
        }

        // GET: api/Lots
        [HttpGet]
        public async Task<IActionResult> GetLots()
        {
            return Ok(await _repositoryManager.Lot.GetAll(false));
        }

        // GET: api/Lots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lot>> GetLot(int id)
        {
            var lot = await _repositoryManager.Lot.GetById(id, false);

            if (lot == null)
            {
                return NotFound();
            }

            return lot;
        }

        //GET: api/Lots/Steps
        [HttpGet("{id}/Steps")]
        public async Task<IActionResult> GetLotsSteps(int id)
        {
            Lot lot = await _repositoryManager.Lot.GetById(id, false);
            if (lot == null)
                return NotFound();

            var steps = await _repositoryManager.Step.GetAll(false);
            return Ok(steps.Where(s => s.LotId == id).ToList());
        }

        //GET: api/Lots/StartDate
        [HttpGet("{StartDate}/lots")]
        public async Task<ActionResult<IEnumerable<Lot>>> GetLotsByDate(DateTime StartDate)
        {
            var lots = await _repositoryManager.Lot.GetAll(false);
            return lots.Where(lot=>lot.StartDate == StartDate).ToList();
        }

        // POST: api/Lots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Lot> PostLot(Lot lot)
        {
            if (lot == null)
            {
                return BadRequest();
            }

            _repositoryManager.Lot.CreateLot(lot);
            _repositoryManager.Save();

            return CreatedAtAction("GetLot", new { id = lot.Id }, lot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLot(int id, Lot lot)
        {
            Lot oldLot = await _repositoryManager.Lot.GetById(id,false);
            if (oldLot == null)
                return NotFound();

            lot.StartPrice = oldLot.StartPrice;
            _repositoryManager.Lot.UpdateLot(lot);
            _repositoryManager.Save();
            return Ok(lot);
        }
       
    }
}

