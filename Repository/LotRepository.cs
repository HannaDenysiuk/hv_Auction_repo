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


        public async  Task<IEnumerable<Lot>> GetAll(bool trackChnges)
        {
            return await FindAll(trackChnges).ToListAsync();
        }

        public async  Task<Lot> GetById(int id, bool v)
        {
            return await FindByCondition(p => p.Id == id, v).FirstAsync();

        }

        public void UpdateLot(Lot lot)
        {
            Update(lot);
        }
    }
}
