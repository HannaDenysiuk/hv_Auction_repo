using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class StepRepository : RepositoryBase<Step>, IStepRepository
    {
        public StepRepository(ApplicationContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateStep(Step step)
        {
            Create(step);
        }

        public void DeleteStep(Step step)
        {
            Delete(step);
        }

        public async Task<IEnumerable<Step>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Step> GetById(int id, bool v)
        {
            return await FindByCondition(p => p.Id == id, v).FirstAsync();

        }

        public void UpdateStep(Step step)
        {
            Update(step);
        }
    }
}
