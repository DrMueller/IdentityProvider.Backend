using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.ConsentRequests;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos.Profiles
{
    public class ScopeToConsentDtoProfile : Profile
    {
        public ScopeToConsentDtoProfile()
        {
            CreateMap<ScopeToConsent, ScopeToConsentDto>()
                .ForMember(d => d.Description, c => c.MapFrom(f => f.Description))
                .ForMember(d => d.DisplayName, c => c.MapFrom(f => f.DisplayName))
                .ForMember(d => d.Emphasize, c => c.MapFrom(f => f.Emphasize))
                .ForMember(d => d.IsRequired, c => c.MapFrom(f => f.IsRequired))
                .ForMember(d => d.Name, c => c.MapFrom(f => f.UniqueName));
        }
    }
}