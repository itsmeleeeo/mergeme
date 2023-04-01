using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    public class RecruiterPUT
    {
        public static string Template => "/recruiter/{id:int}";
        public static string[] Method => new string[] { HttpMethod.Put.ToString() };

        public static Delegate Handler => Action;

        public static IResult Action([FromRoute]int id, RecruiterRequest recruiterRequest, ApplicationDbContext context) 
        {
            var recruiter = context.Recruiter.FirstOrDefault(c => c.Id == id);

            if(recruiter == null)
            {
                return Results.BadRequest();
            }

            recruiter.EditInfo(recruiterRequest.companyName, recruiterRequest.profileImageUrl, recruiterRequest.userBio);

            if(!recruiter.IsValid)
            {
                return Results.BadRequest();
            }

            context.SaveChanges();

            return Results.Ok();
        }
    }
}