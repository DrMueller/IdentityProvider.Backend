using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers.Implementation;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Dtos.Profiles
{
    public class LoginResultDtoProfile : Profile
    {
        public LoginResultDtoProfile()
        {
            CreateMap<Left<ServiceError, LogInSuccess>, LoginResultDto>()
                .ForMember(f => f.ErrorMessage, c => c.MapFrom(f => f.Content.ErrorMessage))
                .ForMember(f => f.SuccessReturnUrl, c => c.MapFrom(f => string.Empty))
                .ForMember(f => f.WasSuccess, c => c.MapFrom(f => false));

            CreateMap<Right<ServiceError, LogInSuccess>, LoginResultDto>()
                .ForMember(f => f.ErrorMessage, c => c.MapFrom(f => string.Empty))
                .ForMember(f => f.SuccessReturnUrl, c => c.MapFrom(f => f.Content.ReturnPath))
                .ForMember(f => f.WasSuccess, c => c.MapFrom(f => true));
        }
    }
}