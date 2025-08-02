using AutoMapper;
using Web.Business.DTO;
using Web.Domain.Entities;

namespace Web.Business.Mapping.Maps
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractEntity, ContractDTO>();
        }
    }
}
