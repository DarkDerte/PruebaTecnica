using Web.Domain.Entities;

namespace Web.Domain.Interfaces
{
    public interface IContractRepository
    {      
        Task<IEnumerable<ContractEntity>> GetAllAsync();
        Task<ContractEntity?> GetByIdAsync(ulong id);
        Task<ContractEntity> AddAsync(ContractEntity contract);
        Task UpdateAsync(ContractEntity contract);
        Task DeleteAsync(ulong id);
    }
}
