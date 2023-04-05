using MergeMe.Model;
using Microsoft.EntityFrameworkCore;

namespace MergeMe.Controllers
{
    public class StackDeveloperPOST
    {
        public static string Template => "/developerstacks";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(StackRequest stackRequest, ApplicationDbContext context)
        {
            var devList = context.Developer.ToList();
            var dev = devList.LastOrDefault();
            var devId = dev.Id;
            var stack = new StackFromDeveloper(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, devId);

            if(stack == null) {
                return Results.BadRequest();
            }

            context.DeveloperStack.Add(stack);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}