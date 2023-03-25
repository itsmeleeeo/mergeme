using Flunt.Notifications;
using Flunt.Validations;

namespace MergeMe.Model
{
    public class Developer : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserBio { get; set; }

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

        public void EditInfo(string position, string profileImg, string userbio)
        {
            Position = position;
            ProfileImageUrl = profileImg;
            UserBio = userbio;
        }

    }
}
