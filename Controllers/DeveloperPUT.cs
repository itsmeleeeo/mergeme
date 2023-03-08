using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MergeMe.Controllers
{
    public class DeveloperPUT
    {
        public static string Template => "/developer/{id}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute]int id, HttpContext http, DeveloperRequest developerRequest, ApplicationDbContext context)
        {
            var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var developer = context.Developer.Where(c => c.Id == id).FirstOrDefault();

            if(developer == null)
            {
                return Results.BadRequest();
            }

           developer.EditInfo(developerRequest.firstName, developerRequest.lastName, developerRequest.profileImageUrl, developerRequest.userBio, developerRequest.StackFromDevelopers);

            if(!developer.IsValid)
            {
                return Results.BadRequest();
            }

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
