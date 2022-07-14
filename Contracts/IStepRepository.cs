using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStepRepository
    {
        Task<IEnumerable<Step>> GetAll(bool trackChanges);
        Task<Step> GetById(int id, bool v);
        void CreateStep(Step step);
        void UpdateStep(Step step);
        void DeleteStep(Step step);
    }
}
