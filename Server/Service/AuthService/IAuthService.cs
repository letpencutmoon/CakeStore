namespace CakeStore.Server.Service.AuthService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<int>> Register(User user,string password);
        public Task<bool> UserExists(string tel);
        public Task<ServiceResponse<string>> LogIn(string tel, string password);
        public Task<ServiceResponse<bool>> ChangePassword(int userId,string newPassword);

        public int GetUserId();
    }
}
