using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class StackDeveloperPUT {
        public static string Template => "/stack/{id:int}";
        public static string[] Method => new string[] {HttpMethod.Put.ToString()};

        public static Delegate Handler => Action;

        public static IResult Action([FromRoute] int id, StackRequest stackRequest, ApplicationDbContext context) {
            var stack = context.DeveloperStack.Where(s => s.Id == id).FirstOrDefault();
            
            if(stack == null)
            {
                return Results.BadRequest();
            }

            stack.EditStack(stackRequest.stackOne, stackRequest.stackTwo, stackRequest.stackThree, stackRequest.id);
            
            context.SaveChanges();

            return Results.Ok();
        }
    }
}