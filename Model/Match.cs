namespace MergeMe.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public Developer developers { get; set; }
        public Recruiter recruiters { get; set; }
    }
}
