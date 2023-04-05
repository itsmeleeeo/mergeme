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
        public string Position { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserBio { get; set; }

        public Developer(string firstName, string lastName, string email, string profileImageUrl, string userBio, string position)
        {
            var contract = new Contract<Developer>()
                .IsNotNullOrEmpty(firstName, "FirstName")
                .IsNotNullOrEmpty(lastName, "LastName");
            AddNotifications(contract);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ProfileImageUrl = profileImageUrl;
            Position = position;
            UserBio = userBio;
        }

        public void EditInfo(string firstName, string lastName, string position, string profileImageUrl, string userbio)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.ProfileImageUrl = profileImageUrl;
            this.UserBio = userbio;
        }
    }
}
