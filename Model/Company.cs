namespace MergeMe.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int BussinessNumber { get; set; }

        private Recruiter recruiter { get; set; }
    }
}
