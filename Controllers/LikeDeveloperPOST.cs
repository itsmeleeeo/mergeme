using MergeMe.Migrations;
using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class LikeDeveloperPOST
    {
        public static string DeveloperTemplate => "/developer/like/{id:int}";
        public static string RecruiterTemplate => "/recruiter/like/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context) 
        {
            var recruiter = context.Recruiter.FirstOrDefault(r => r.Id == id);
            var developer = context.Developer.FirstOrDefault(d => d.Id == id);

            while(developer == null || recruiter == null)
            {
                lock(context)
                {
                    recruiter = context.Recruiter.FirstOrDefault(r => r.Id == id);
                    developer = context.Developer.FirstOrDefault(d => d.Id == id);
                }
            }

            if (recruiter == null || developer == null)
            {
                return Results.BadRequest();
            }

            Match match = new Match();

            match.GetMatch(developer.Id, recruiter.Id);
            context.match.Add(match);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}