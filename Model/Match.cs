namespace MergeMe.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }

        private Developer developer { get; set; }
        private Recruiter recruiter { get; set; }
    }
}
