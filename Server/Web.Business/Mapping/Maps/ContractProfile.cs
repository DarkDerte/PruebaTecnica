using AutoMapper;
using Api.Business.DTO;
using Api.Domain.Entities;

namespace Api.Business.Mapping.Maps
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractEntity, ContractDTO>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).
                ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("yyyy-MM-dd"))).
                ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate.HasValue ? src.UpdatedDate.Value.ToString("yyyy-MM-dd") : string.Empty)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<ContractDTO, ContractEntity>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).
                ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.UpdatedDate) ? DateTime.Now : DateTime.Parse(src.CreatedDate))).
                ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.UpdatedDate) ? null : (DateTime?) DateTime.Parse(src.UpdatedDate))).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
