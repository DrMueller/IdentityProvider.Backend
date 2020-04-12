using AutoMapper;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Profiles
{
    public class AccountCreationResultDtoProfile : Profile
    {
        public AccountCreationResultDtoProfile()
        {
            CreateMap<AccountCreationResult, AccountCreationResultDto>()
                .ForMember(d => d.ErrorMessages, c => c.MapFrom(f => f.ErrorMessages));
        }
    }
}