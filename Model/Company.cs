namespace MergeMe.Model
{
    public class Company
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        public int BussinessNumber { get; set; }

        private List<Recruiter> recruiters { get; set; }
    }
}
