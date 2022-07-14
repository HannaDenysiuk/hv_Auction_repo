using Contracts;
using Entities;
using Entities.Models;
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

        public IEnumerable<Step> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Step GetById(int id, bool v)
        {
            return FindByCondition(p => p.Id == id, v).FirstOrDefault();

        }

        public void UpdateStep(Step step)
        {
            Update(step);
        }
    }
}
