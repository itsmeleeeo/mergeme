using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class StackRecruiterPOST
    {
        public static string Template => "/recruiterstack";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(ApplicationDbContext context, StackRequest stackRequest)
        {
            var rec = context.Recruiter.OrderBy(r => r.Id).LastOrDefault();
            var recId = rec.Id;

            var stackFromRecruiter = new StackFromRecruiter();

            stackFromRecruiter.EditStack(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, recId);

            context.RecruiterStack.Add(stackFromRecruiter);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}