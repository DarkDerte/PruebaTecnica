using Api.Business.DTO;

namespace Api.Business.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDTO>> GetAllAsync();

        Task<ContractDTO?> GetContractAsync(ulong id);

        Task UpdateAsync(ContractDTO contract);

        Task<ContractDTO> InsertAsync(ContractDTO contract);
        
        Task DeleteAsync(ulong id);
    }
}
