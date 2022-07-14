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
    public class StepsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public StepsController(IRepositoryManager manager)
        {
            _repositoryManager = manager;
        }

        // GET: api/Steps
        [HttpGet]
        public async Task<IEnumerable<Step>> GetSteps()
        {
            return await _repositoryManager.Step.GetAll(false);
        }

        // GET: api/Steps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStep(int id)
        {
            var step = await _repositoryManager.Step.GetById(id, false);

            if (step == null)
            {
                return NotFound();
            }

            return Ok(step);
        }

        // POST: api/Steps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Step>> PostStep(Step step)
        {
            if (step == null)
            {
                return BadRequest();
            }
            var steps = await _repositoryManager.Step.GetAll(false);
            List<Step> steps1 = steps.Where(s => s.LotId == step.LotId).ToList();
            Lot lot = await _repositoryManager.Lot.GetById(step.LotId,false);

            if (steps.Count() == 0 && lot.StartPrice < step.Amount)
            {
                _repositoryManager.Step.CreateStep(step);
                _repositoryManager.Save();

                return CreatedAtAction("GetStep", new { id = step.Id }, step);
            }
            else if (steps.Count() > 0)
            {
                double sum = steps.Max(s => s.Amount);
                if(sum > step.Amount)
                {
                    return BadRequest("Amount can't be less than last step!");
                }
                else
                {
                    _repositoryManager.Step.CreateStep(step);
                    _repositoryManager.Save();

                    return CreatedAtAction("GetStep", new { id = step.Id }, step);
                }
            }
            return BadRequest();
        }
    }
}
