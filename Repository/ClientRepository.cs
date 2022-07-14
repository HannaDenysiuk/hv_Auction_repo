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
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ApplicationContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public void CreateUser(Client user)
        {
            Create(user);
        }

        public void DeleteUser(Client user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<Client>> GetAll(bool trackCahnges)
        {
            return await FindAll(trackCahnges).ToListAsync();
        }


        public void UpdateUser(Client user)
        {
            Update(user);
        }

        public async Task<Client> GetById(int id, bool v)
        {
            return await FindByCondition(p => p.Id == id, v).FirstAsync();
        }
    }
}
