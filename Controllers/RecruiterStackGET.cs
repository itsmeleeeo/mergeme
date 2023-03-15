using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class RecruiterStackGET
    {
        public static string Template => "/recruiterstack";
        public static string[] Method => new string[] { HttpMethod.Get.ToString() }; 
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext ctx) 
        {
            var recruiterStack = ctx.RecruiterStack.ToList();
            var stacks = recruiterStack.Where(r => r.StackOne != null && r.StackTwo != null && r.StackThree != null)
                            .Select(r => new { r.Id, r.StackOne, r.StackTwo, r.StackThree});

            return Results.Ok(stacks);
        } 
    }
}