namespace MergeMe.Model
{
    public record RecruiterRequest(int id, string firstName, string lastName, string email, string password, string companyName, string profileImageUrl, string userBio);
}