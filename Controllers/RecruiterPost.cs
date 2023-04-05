using MergeMe.Model;
using MergeMe.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MergeMe.Controllers
{
    public class RecruiterPost
    {
        public static string Template => "/recruiter";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(RecruiterRequest recruiterRequest, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            var recruiter = new IdentityUser { UserName = recruiterRequest.email, Email = recruiterRequest.email };
            var result = userManager.CreateAsync(recruiter, recruiterRequest.password).Result;
            var rec = new Recruiter(recruiterRequest.firstName,
            recruiterRequest.email,
            recruiterRequest.profileImageUrl,
            recruiterRequest.userBio);

            context.Recruiter.Add(rec);
            context.SaveChanges();

            if(!result.Succeeded)
            {
                return Results.ValidationProblem(result.Errors.ConvertToProblemToDetails());
            }

            var recruiterClaims = new List<Claim>
            {
                new Claim("CompanyName", recruiterRequest.firstName),
                new Claim("Business Number", recruiterRequest.lastName)
            };

            var claimResult = userManager.AddClaimsAsync(recruiter, recruiterClaims).Result;

            if(!claimResult.Succeeded)
            {
                return Results.ValidationProblem(result.Errors.ConvertToProblemToDetails());
            }

            return Results.Created($"/recruiter/{recruiter.Id}", recruiter.Id);
        }
    }
}
