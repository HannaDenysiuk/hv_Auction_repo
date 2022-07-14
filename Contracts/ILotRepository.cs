using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ILotRepository
    {
        IEnumerable<Lot> GetAll(bool trackChnges);
        Lot GetById(int id, bool v);
        void CreateLot(Lot lot);
        void UpdateLot(Lot lot);
        void DeleteLot(Lot lot);
    }
}
