using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ContractService : IContractService
    {
        IDbRepository context;

        public ContractService(IDbRepository context)
        {
            this.context = context;
        }
        public CreateContractResult CreateContract(ContractModel contract)
        {
            if (CalculateProjectCountFromPrice(contract.Price) < 1)
                return CreateContractResult.FailureSmallPrice;

            if (contract.Id == -1)
                contract.Id = context.Contract.GetList().FirstOrDefault() == null ? 1 : context.Contract.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            Contract c = new Contract
            {
                Id = contract.Id,
                CustomerId = contract.CustomerId,
                EndDate = contract.EndDate,
                StartDate = contract.StartDate,
                Price = contract.Price,
                ProjectCount = contract.ProjectCount,
                Customer = context.Customer.GetItem(contract.CustomerId),
                Project = new List<Project> (),
            };

            context.Contract.Create(c);

            context.Save();

            return CreateContractResult.Success;
        }

        public List<ContractModel> GetContracts()
        {
            return context.Contract.GetList().Select(i  => new ContractModel(i)).ToList();
        }

        public int GetCurrentProjectCountForContract(int contractId)
        {
            return context.Project.GetList().Where(i => i.ContractId == contractId).Count();
        }

        public int CalculateProjectCountFromPrice(decimal price)
        {
            return (int)(price / 10000);
        }
    }
}
