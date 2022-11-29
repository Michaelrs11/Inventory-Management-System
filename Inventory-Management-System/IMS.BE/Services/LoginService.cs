using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IMS.BE.Services
{
    public class LoginService
    {
        private readonly IMSDBContext db;

        public LoginService(IMSDBContext db)
        {
            this.db = db;
        }

        public async Task<ClaimsPrincipal> Login(string authScheme, string email, string password)
        {
            var user = await this.GetUserAsync(email);

            if (user == null)
            {
                return null;
            }

            var isPasswordValid = this.VerifyPassword(user, password);

            if (isPasswordValid == false)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserCode)
            };

            var claimsIdentity = new ClaimsIdentity(claims, authScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }

        public bool VerifyPassword(MasterUser user, string password)
        {
            var userPasswordHash = user.Password;
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, userPasswordHash);

            return isPasswordValid;
        }

        public async Task<MasterUser> GetUserAsync(string email)
        {
            var tolowerEmail = email.ToLower();

            var user = await this.db.MasterUsers
                .Where(Q => Q.Email.ToLower() == tolowerEmail)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
