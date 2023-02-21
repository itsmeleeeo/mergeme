using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Identity;

namespace MergeMe.Model
{
    public class Developer : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserBio { get; set; }

        private List<Match> Matches { get; set; }
        private List<StackFromDeveloper> StackFromDeveloper { get; set; }

        public Developer(string firstName, string lastName, string email, string password, string profileImageUrl, string userBio)
        {
            var contract = new Contract<Developer>()
                .IsNotNullOrEmpty(firstName, "FirstName")
                .IsNotNullOrEmpty(lastName, "LastName");
            AddNotifications(contract);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ProfileImageUrl = profileImageUrl;
            UserBio = userBio;
        }

        public void EditInfo(string firstName, string lastName, string profileImg, string userbio, List<StackFromDeveloper> stackFromDeveloper)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImageUrl = profileImg;
            UserBio = userbio;
            StackFromDeveloper = stackFromDeveloper;
        }

    }
}
