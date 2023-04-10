using MergeMe.Model;
using Microsoft.AspNetCore.Authorization;

namespace MergeMe.Controllers
{
    public class DashboardRecruiterGet
    {
        public static string Template => "/dashboard/recruiter";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var developer = context.Developer.ToList();
            var response = developer.Select(d => new DeveloperResponse {Id = d.Id, FirstName = d.FirstName, LastName = d.LastName, 
                Email = d.Email,
                ProfileImageUrl = d.ProfileImageUrl, 
                UserBio = d.UserBio, 
                Position = d.Position  
            });

            return Results.Ok(response);
        }
    }
}
