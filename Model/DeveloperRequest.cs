namespace MergeMe.Model
{
    public record DeveloperRequest(string id, string firstName, string lastName, string email, string password,string position, string profileImageUrl, string userBio, List<StackFromDeveloper> StackFromDevelopers);
}