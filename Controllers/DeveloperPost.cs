using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class DeveloperPost 
    {
        public static string Template => "/developer";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(DeveloperRequest developerRequest, ApplicationDbContext ctx)
        {
            var developer = new Developer
            {
                FirstName = developerRequest.firstName,
                LastName = developerRequest.lastName,
                BirthDate = DateTime.Today,
                Email = developerRequest.email,
                password = developerRequest.password,
            };

            ctx.Developer.Add(developer);
            ctx.SaveChanges();

            return Results.Created($"/developer/{developer.Id}", developer.Id);
        }
    }
}
