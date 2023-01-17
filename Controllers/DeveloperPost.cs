using MergeMe.Model;
using MergeMe.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MergeMe.Controllers
{
    public class DeveloperPost
    {
        public static string Template => "/developer";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(DeveloperRequest developerRequest, UserManager<IdentityUser> userManager)
        {
            var developer = new IdentityUser { UserName = developerRequest.email, Email = developerRequest.email};
            var result = userManager.CreateAsync(developer, developerRequest.password).Result;

            if(!result.Succeeded)
            {
                return Results.ValidationProblem(result.Errors.ConvertToProblemToDetails());
            }

            var developerClaims = new List<Claim>
            {
                new Claim("FirstName", developerRequest.firstName),
                new Claim("LastName", developerRequest.lastName)
            };

            var claimResult = userManager.AddClaimsAsync(developer, developerClaims).Result;

            if(!claimResult.Succeeded)
            {
                return Results.BadRequest(claimResult.Errors.ConvertToProblemToDetails());
            }

            return Results.Created($"/developer/{developer.Id}", developer.Id);
        }
    }
}
