namespace CakeStore.Client.Service.AuthService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<int>> Register(UserRegister userRegister);
        public Task<ServiceResponse<string>> LogIn(UserLogin userLogin);

        public Task<ServiceResponse<bool>> ChangePassword(UserPasswordChange userChange);

    }
}
