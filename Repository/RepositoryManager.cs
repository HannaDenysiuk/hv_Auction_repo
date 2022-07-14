using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationContext repositoryContext;
        private IClientRepository clientRepository;
        private ILotRepository lotRepository;
        private IStepRepository stepRepository;
        public RepositoryManager(ApplicationContext _repositoryContext)
        {
            repositoryContext = _repositoryContext;
        }

        public IStepRepository Step
        {
            get
            {
                if(stepRepository == null)
                {
                   stepRepository = new StepRepository(repositoryContext);
                }
                return stepRepository;
            }
        }
        public ILotRepository Lot
        {
            get
            {
                if(lotRepository == null)
                {
                    lotRepository = new LotRepository(repositoryContext);
                }
                return lotRepository;
            }
        }

        public IClientRepository Client
        {
            get
            {
                if(clientRepository == null)
                {
                    clientRepository = new ClientRepository(repositoryContext);
                }
                return clientRepository;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
