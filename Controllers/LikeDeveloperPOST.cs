using MergeMe.Migrations;
using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class LikeDeveloperPOST
    {
        public static string Template => "/developer/like/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context) 
        {
            var recruiter = context.Recruiter.FirstOrDefault(r => r.Id == id);

            if (recruiter == null)
            {
                return Results.BadRequest();
            }

            Match match = new Match();

            match.GetMatch(1, recruiter.Id);
            context.match.Add(match);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}