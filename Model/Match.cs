namespace MergeMe.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }

        public Developer developer { get; set; }
        public Recruiter recruiter { get; set; }
    }
}
