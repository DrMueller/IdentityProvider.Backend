using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models.LogOut;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Dtos.LogOut.Profiles
{
    public class LogOutResultDtoProfile : Profile
    {
        public LogOutResultDtoProfile()
        {
            CreateMap<LogoutResult, LogOutResultDto>()
                .ForMember(d => d.PostLogoutPath, c => c.MapFrom(f => f.PostLogoutPath));
        }
    }
}