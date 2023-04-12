using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class StackDeveloperPOST
    {
        public static string Template => "/developerstack";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context, StackRequest stackRequest)
        {
            var dev = context.Developer.OrderBy(d => d.Id).LastOrDefault();
            var devId = dev.Id;

            var stackFromDeveloper = new StackFromDeveloper();
            stackFromDeveloper.EditStack(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, devId);

            context.DeveloperStack.Add(stackFromDeveloper);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}