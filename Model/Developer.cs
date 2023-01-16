namespace MergeMe.Model
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        private List<Match> matches { get; set; } 

    }
}
