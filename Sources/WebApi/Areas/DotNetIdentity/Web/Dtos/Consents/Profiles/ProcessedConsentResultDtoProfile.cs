using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents.Profiles
{
    public class ProcessedConsentResultDtoProfile : Profile
    {
        public ProcessedConsentResultDtoProfile()
        {
            CreateMap<ProcessedConsentResult, ProcessedConsentResultDto>()
                .ForMember(d => d.ErrorMessage, c => c.MapFrom(f => f.ErrorMessage))
                .ForMember(d => d.RedirectPath, c => c.MapFrom(f => f.RedirectPath))
                .ForMember(d => d.WasSuccess, c => c.MapFrom(f => f.WasSuccess));
        }
    }
}