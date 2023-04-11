namespace MergeMe.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int developersId { get; set; }
        public Developer developers { get; set; }
        public int recruitersId { get; set; }
        public Recruiter recruiters { get; set; }

        public Match()
        {
        }

        public void GetMatch(int recId, int devId)
        {
            MatchDate = DateTime.Now;
            recruitersId = recId;
            developersId = devId;
        }
    }
}
