using System.Collections.Generic;


namespace BLL
{
    public enum CreateContractResult { Success, FailureSmallPrice};
    public interface IContractService
    {
        List<ContractModel> GetContracts();
        CreateContractResult CreateContract(ContractModel contract);
        int GetCurrentProjectCountForContract(int contractId);
        int CalculateProjectCountFromPrice(decimal price);
    }
}
