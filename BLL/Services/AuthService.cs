using BCrypt.Net;
using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        AppDbContext db;
        public AuthService(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<ClaimsPrincipal> Login(string username, string password)
        {
            var user = await db.SystemUsers
                .FirstOrDefaultAsync(u => u.Username == username );
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.GetType().Name) // Admin, Doctor, etc.
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
