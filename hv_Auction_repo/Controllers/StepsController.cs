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
        public IEnumerable<Step> GetSteps()
        {
            return _repositoryManager.Step.GetAll(false).ToList();
        }

        // GET: api/Steps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStep(int id)
        {
            var step = _repositoryManager.Step.GetById(id, false);

            if (step == null)
            {
                return NotFound();
            }

            return step;
        }

        // POST: api/Steps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Step> PostStep(Step step)
        {
            if (step == null)
            {
                return BadRequest();
            }
            List<Step> steps = _repositoryManager.Step.GetAll(false).Where(s => s.LotId == step.LotId).ToList();
            Lot lot = _repositoryManager.Lot.GetById(step.LotId,false);

            if (steps.Count == 0 && lot.StartPrice < step.Amount)
            {
                _repositoryManager.Step.CreateStep(step);
                _repositoryManager.Save();

                return CreatedAtAction("GetStep", new { id = step.Id }, step);
            }
            else if (steps.Count > 0)
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
