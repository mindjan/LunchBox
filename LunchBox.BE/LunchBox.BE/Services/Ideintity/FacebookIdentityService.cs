using System;
using System.Net.Http;
using System.Threading.Tasks;
using LunchBox.BE.Contracts.Identity;

namespace LunchBox.BE.Services.Ideintity
{
    public class FacebookIdentityService : IFacebookIdentityService
    {
        public async Task<FacebookIdentity> VerifyFacebookAccessToken(string accessToken)
        {
            FacebookIdentity fbUser = null;
            var path = "https://graph.facebook.com/me?access_token=" + accessToken;
            var client = new HttpClient();
            var uri = new Uri(path);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                fbUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookIdentity>(content);
            }

            return fbUser;
        }
    }
}
