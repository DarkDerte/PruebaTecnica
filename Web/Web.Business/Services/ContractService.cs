using AutoMapper;
using System.Collections.Generic;
using Web.Business.DTO;
using Web.Business.Interfaces;
using Web.Domain.Entities;
using Web.Domain.Interfaces;

namespace Web.Business.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractDTO>> GetAllAsync() => _mapper.Map<IEnumerable<ContractDTO>>(await _repository.GetAllAsync());

        public async Task<ContractDTO?> GetContractAsync(ulong id) => _mapper.Map<ContractDTO?>(await _repository.GetByIdAsync(id));

        public async Task UpdateAsync(ContractDTO contract) => await _repository.UpdateAsync(_mapper.Map<ContractEntity>(contract));

        public async Task<ContractDTO?> InsertAsync(ContractDTO contract) => _mapper.Map<ContractDTO?>(await _repository.AddAsync(_mapper.Map<ContractEntity>(contract)));

        public async Task DeleteAsync(ulong id) => await _repository.DeleteAsync(id);

    }
}
