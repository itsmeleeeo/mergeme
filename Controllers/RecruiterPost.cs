using MergeMe.Model;

namespace MergeMe.Controllers
{
    public class RecruiterPost
    {
        public static string Template => "/recruiter";
        public static string[] Method => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(RecruiterRequest recruiterRequest, ApplicationDbContext ctx)
        {
            var recruiter = new Recruiter
            {
                FirstName = recruiterRequest.firstName,
                LastName = recruiterRequest.lastName,
                BirthDate = DateTime.Today,
                Email = recruiterRequest.email,
                password = recruiterRequest.password

            };

            ctx.Recruiter.Add(recruiter);
            ctx.SaveChanges();

            return Results.Created($"/recruiter/{recruiter.Id}", recruiter.Id);
        }
    }
}
