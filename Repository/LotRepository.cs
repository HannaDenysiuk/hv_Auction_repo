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
    public class LotRepository : RepositoryBase<Lot>, ILotRepository
    {
        public LotRepository(ApplicationContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public void CreateLot(Lot lot)
        {
            Create(lot);
        }

        public void DeleteLot(Lot lot)
        {
            Delete(lot);
        }

        public IEnumerable<Lot> GetAll(bool trackChnges)
        {
            return FindAll(trackChnges).ToList();
        }

        public Lot GetById(int id, bool v)
        {
            return FindByCondition(p => p.Id == id, v).FirstOrDefault();

        }

        public void UpdateLot(Lot lot)
        {
            Update(lot);
        }
    }
}
