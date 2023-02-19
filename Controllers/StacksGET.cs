using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class StacksGET
    {
        public static string Template => "/stack";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var stack = context.Stack.ToList();
            var response = stack.Select(s => new StackResponse { StackName = s.StackName });

            return Results.Ok(response);
        }
    }
}
