using Flunt.Notifications;
using Flunt.Validations;

namespace MergeMe.Model
{
    public class Recruiter : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private Company Company { get; set; }
        private List<Match> matches { get; set; }

        public Recruiter(string firstName, string lastName, string email, string password)
        {
            var contract = new Contract<Recruiter>()
                .IsNotNullOrEmpty(firstName, "FirstName")
                .IsNotNullOrEmpty(lastName, "LastName")
                .IsNotNullOrEmpty(email, "Email")
                .IsNotNullOrEmpty(password, "Password");
            AddNotifications(contract);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
