using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class MatchPOST
    {
        public static string Template => "/match";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context, MatchRequest matchRequest) 
        {
            var match = new Match {
                Id = matchRequest.id,
                MatchDate = matchRequest.matchDate,
            };
            context.match.Add(match);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}