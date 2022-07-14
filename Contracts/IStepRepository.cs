using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IStepRepository
    {
        IEnumerable<Step> GetAll(bool trackChanges);
        Step GetById(int id, bool v);
        void CreateStep(Step step);
        void UpdateStep(Step step);
        void DeleteStep(Step step);
    }
}
