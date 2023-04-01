using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class StackRecruiterPUT 
    {
        public static string Template => "/recruiterstacks/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, StackRequest stackRequest, ApplicationDbContext context) 
        {
            var recruiter = context.Recruiter.FirstOrDefault(d => d.Id == id);
            var stack = context.RecruiterStack.FirstOrDefault(s => s.recruiters.Id == recruiter.Id);

            var editedStack = stack.recruiters.Id;

            if(stack == null)
            {
                return Results.BadRequest();
            }
            
            stack.EditStack(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, editedStack);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}