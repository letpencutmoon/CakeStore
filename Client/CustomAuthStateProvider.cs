using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace CakeStore.Client
{
    //大为震惊，看不太懂的代码，又点超出我的理解能力
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorageService,HttpClient http)
        {
            this._localStorageService = localStorageService;
            this._http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authtoken =  await _localStorageService.GetItemAsStringAsync("authToken");
            var identify = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(authtoken))
            {
                try
                {
                    identify =new ClaimsIdentity(ParseClaimsFromJwt(authtoken!),"Jwt");
                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authtoken.Replace("\"",""));
                }
                catch
                {
                    await _localStorageService.RemoveItemAsync("authToken");
                    identify = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identify);
            var state =new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:base64 += "==";break;
                case 3:base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePair = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = keyValuePair.Select(kvp =>new Claim(kvp.Key,kvp.Value.ToString()));

            return claims;
        }
    }
}
