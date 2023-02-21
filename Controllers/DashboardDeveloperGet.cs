using MergeMe.Model;
using Microsoft.AspNetCore.Authorization;

namespace MergeMe.Controllers
{
    public class DashboardDeveloperGet
    {
        public static string Template => "/dashboard/developer";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var recruiter = context.Recruiter.ToList();
            var response = recruiter.Select(r => new RecruiterResponse {CompanyName = r.FirstName + " " + r.LastName, Id = r.Id, Userbio = r.UserBio, profileImageUrl = r.ProfileImageUrl});

            return Results.Ok(response);
        }
    }
}
