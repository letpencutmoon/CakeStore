using CakeStore.Server.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CakeStore.Server.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext dataContext,IConfiguration configuration)
        {
            this._context = dataContext;
            this._configuration = configuration;
        }

        public async Task<ServiceResponse<string>> LogIn(string tel, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await  _context.User.FirstOrDefaultAsync(p=>p.Tel==tel);

            if(user == null)
            {
                response.Success = false;
                response.Message = "用户不存在";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success=false;
                response.Message = "密码错误";
            }
            else
            {
                response.Success=true;
                response.Data = CreateToken(user);
                response.Message = "登录成功";
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if(await UserExists(user.Tel))
            {
                return new ServiceResponse<int> { 
                    Success = false,
                    Message = "用户已存在"
                };
            }

            CreatePasswordHash(password,out byte[] passwordHash,out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> {Data = user.ID,Message="注册成功"};
        }

        public async Task<bool> UserExists(string tel)
        {
            if(await _context.User.AnyAsync(p => p.Tel.Equals(tel)))
            {
                return true;
            }
            return false;
        }

        //使用hmacha512算法生成散列值和盐
        private void CreatePasswordHash(string password,out byte[] passwordhash,out byte[] passwordsalt)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        //比对密码的散列值和数据库中的哈希值
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac =new HMACSHA512(passwordSalt))
            {
                var newHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return newHash.SequenceEqual(passwordHash);
            }
        }

        //生成登录令牌(不太能看懂这些对象是啥是干嘛的)
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Tel)
            };

            var key =new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                    claims:claims,
                    expires:DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt=new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

		public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
		{
            var user = await _context.User.FindAsync(userId);
            if(user == null)
			{
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "未找到该用户"
                };
			}

            CreatePasswordHash(newPassword,out byte[] passwordHash,out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true,Message="密码已更改" };
		}
	}
}
