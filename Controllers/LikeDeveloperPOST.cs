using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class LikeDeveloperPOST
    {
        public static string Template => "/developer/like/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context, RecruiterRequest recruiterRequest) 
        {
            var recruiter = context.Recruiter.FirstOrDefault(r => r.Id == id);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}