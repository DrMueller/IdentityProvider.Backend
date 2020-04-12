using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.UserResponses;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos.Profiles
{
    public class ProcessedConsentResultDtoProfile : Profile
    {
        public ProcessedConsentResultDtoProfile()
        {
            CreateMap<Left<ServiceError, ProcessedUserConsent>, ProcessedConsentResultDto>()
                .ForMember(d => d.ErrorMessage, c => c.MapFrom(f => f.Content.ErrorMessage))
                .ForMember(d => d.RedirectPath, c => c.MapFrom(f => string.Empty))
                .ForMember(d => d.WasSuccess, c => c.MapFrom(f => false));

            CreateMap<Right<ServiceError, ProcessedUserConsent>, ProcessedConsentResultDto>()
                .ForMember(d => d.ErrorMessage, c => c.MapFrom(f => string.Empty))
                .ForMember(d => d.RedirectPath, c => c.MapFrom(f => f.Content.RedirectPath))
                .ForMember(d => d.WasSuccess, c => c.MapFrom(f => true));
        }
    }
}