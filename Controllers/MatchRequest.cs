using MergeMe.Model;

namespace MergeMe.Controllers
{
    public record MatchRequest(int id, DateTime matchDate, Developer developerId, Recruiter recruiterId);
}