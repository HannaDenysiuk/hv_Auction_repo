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
        public ActionResult<IEnumerable<Lot>> GetLots()
        {
            return _repositoryManager.Lot.GetAll(false).ToList();
        }

        // GET: api/Lots/5
        [HttpGet("{id}")]
        public ActionResult<Lot> GetLot(int id)
        {
            var lot = _repositoryManager.Lot.GetById(id, false);

            if (lot == null)
            {
                return NotFound();
            }

            return lot;
        }

        //GET: api/Lots/Steps
        [HttpGet("{id}/Steps")]
        public ActionResult<IEnumerable<Lot>> GetLotsSteps(int id)
        {
            Lot lot = _repositoryManager.Lot.GetById(id, false);
            if (lot == null)
                return NotFound();

            var steps = _repositoryManager.Step.GetAll(false).Where(s => s.LotId == id).ToList();
            return Ok(steps);
        }

        //GET: api/Lots/StartDate
        [HttpGet("{StartDate}/lots")]
        public ActionResult<IEnumerable<Lot>> GetLotsByDate(DateTime StartDate)
        {
            return _repositoryManager.Lot.GetAll(false).Where(lot=>lot.StartDate == StartDate).ToList();
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

       
    }
}
