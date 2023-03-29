using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class DeveloperStackGET
    {
        public static string Template => "/developerstack";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var developerStack = context.DeveloperStack.ToList();
            var stacks = developerStack.Where(r => r.StackOne != null && r.StackTwo != null && r.StackThree != null)
                            .Select(r => new { r.Id, r.StackOne, r.StackTwo, r.StackThree});

            return Results.Ok(stacks);
        }
    }
}