using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILotRepository
    {
        Task<IEnumerable<Lot>> GetAll(bool trackChnges);
        Task<Lot> GetById(int id, bool v);
        void CreateLot(Lot lot);
        void UpdateLot(Lot lot);
        void DeleteLot(Lot lot);
    }
}
