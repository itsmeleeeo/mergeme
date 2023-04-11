using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class LikeRecruiterPOST
    {
        public static string Template => "/recruiter/like/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            var developer = context.Developer.FirstOrDefault(d => d.Id == id);

            if (developer == null)
            {
                return Results.BadRequest();
            }

            Match match = new Match();

            match.GetMatch(developer.Id, 1);
            context.match.Add(match);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}