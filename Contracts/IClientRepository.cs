
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll(bool trackCahnges);
        Task<Client> GetById(int id, bool v);
        void CreateUser(Client user);
        void UpdateUser(Client user);
        void DeleteUser(Client user);
    }
}
