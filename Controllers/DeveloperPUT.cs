using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MergeMe.Controllers
{
    public class DeveloperPUT
    {
        public static string Template => "/developer/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute]int id, DeveloperRequest developerRequest, ApplicationDbContext context)
        {
            var developer = context.Developer.Where(c => c.Id == id).FirstOrDefault();

            if(developer == null)
            {
                return Results.BadRequest();
            }

           developer.EditInfo(developerRequest.position, developerRequest.profileImageUrl, developerRequest.userBio);
            if(!developer.IsValid)
            {
                return Results.BadRequest();
            }

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
