using MergeMe.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MergeMe.Controllers
{
    public class LoginPost
    {
        public static string Template => "/login";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(LoginRequest loginRequest, IConfiguration configuration , UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            var user = userManager.FindByEmailAsync(loginRequest.email).Result;
            var userInfo = userManager.GetClaimsAsync(user);

            if (user == null)
            {
                return Results.BadRequest();
            }

            if(!userManager.CheckPasswordAsync(user, loginRequest.password).Result)
            {
                return Results.BadRequest();
            }

            var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, loginRequest.email)
                }),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configuration["JwtBearerTokenSettings:Audience"],
                Issuer = configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var dev = context.Developer.FirstOrDefault(d => d.Email == user.Email);
            var rec = context.Recruiter.FirstOrDefault(r => r.Email == user.Email);

            if(dev != null)
            {
                return Results.Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    userInfo = userInfo,
                    user = user.Id,
                    dev = dev.Id
                });
            } else
            {
                return Results.Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    userInfo = userInfo,
                    user = user.Id,
                    rec = rec.Id
                });
            }
        }
    }
}
