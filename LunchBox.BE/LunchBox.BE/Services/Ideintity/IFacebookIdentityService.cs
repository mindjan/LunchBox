using System.Threading.Tasks;
using LunchBox.BE.Contracts.Identity;

namespace LunchBox.BE.Services.Ideintity
{
    public interface IFacebookIdentityService
    {
        Task<FacebookIdentity> VerifyFacebookAccessToken(string accessToken);
    }
}