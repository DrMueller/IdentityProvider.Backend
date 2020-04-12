using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.ConsentRequests;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos.Profiles
{
    public class ConsentRequestDtoProfile : Profile
    {
        public ConsentRequestDtoProfile()
        {
            CreateMap<ConsentRequest, ConsentRequestDto>()
                .ForMember(d => d.AllowRememberConsent, c => c.MapFrom(f => f.AllowToRememberConsent))
                .ForMember(d => d.ClientName, c => c.MapFrom(f => f.ClientName))
                .ForMember(d => d.ClientUri, c => c.MapFrom(f => f.ClientUri))
                .ForMember(d => d.IdentityScopes, c => c.MapFrom(f => f.IdentityScopes))
                .ForMember(d => d.ResourceScopes, c => c.MapFrom(f => f.ResourceScopes))
                .ForMember(d => d.ReturnUrl, c => c.MapFrom(f => f.ReturnUrl));
        }
    }
}