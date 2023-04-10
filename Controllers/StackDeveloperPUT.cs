using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class StackDeveloperPUT 
    {
        public static string Template => "/developerstacks/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, StackRequest stackRequest, ApplicationDbContext context) 
        {
            var developer = context.Developer.FirstOrDefault(d => d.Id == id);
            var stack = context.DeveloperStack.FirstOrDefault(s => s.developers.Id == developer.Id);

            var editedStack = stack.developers.Id;
            var stackId = stack.Id;

            if(stack == null)
            {
                return Results.BadRequest();
            }
            
            stack.EditStack(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, editedStack, stackId);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}