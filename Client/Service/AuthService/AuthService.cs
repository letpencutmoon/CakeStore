namespace CakeStore.Client.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client)
        {
            this._client = client;
        }

		public async Task<ServiceResponse<bool>> ChangePassword(UserPasswordChange userChange)
		{
            var result =await _client.PostAsJsonAsync("api/auth/change-password",userChange.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
		}

		public async Task<ServiceResponse<string>> LogIn(UserLogin userLogin)
        {
            var result = await _client.PostAsJsonAsync("api/auth/login",userLogin);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister userRegister)
        {
            var result = await _client.PostAsJsonAsync("api/auth/register",userRegister);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
