namespace MergeMe.Model
{
    public class Recruiter
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        private Company Company { get; set; }
        private List<Match> matches { get; set; }
    }
}
