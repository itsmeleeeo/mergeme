using Flunt.Notifications;
using Flunt.Validations;

namespace MergeMe.Model
{
    public class Recruiter : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string CompanyName { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserBio { get; set; }

        public List<StackFromRecruiter> stackFromRecruiter { get; set; }

        public Recruiter(int id,string companyName, string email, string password, string profileImageUrl, string userBio)
        {
            var contract = new Contract<Recruiter>()
                .IsNotNullOrEmpty(companyName, "CompanyName");
            AddNotifications(contract);
            Id = id;
            CompanyName = companyName;
            Email = email;
            Password = password;
            ProfileImageUrl = profileImageUrl;
            UserBio = userBio;
        }
    }
}
