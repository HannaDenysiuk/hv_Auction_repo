using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IClientRepository Client { get; }
        IStepRepository Step { get; }
        ILotRepository Lot { get; }
        void Save();
    }
}
