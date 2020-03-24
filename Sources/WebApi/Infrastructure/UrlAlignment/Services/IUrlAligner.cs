namespace Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services
{
    public interface IUrlAligner
    {
        string MakePathRelative(string absolutePath);
    }
}