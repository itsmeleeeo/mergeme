namespace MergeMe.Model
{
    public class StackFromRecruiter
    {
        public int Id { get; set; }
        public string StackOne { get; set; }
        public string StackTwo { get; set; }
        public string StackThree { get; set; }
        public Recruiter recruiters { get; set; }
        public int recruitersId { get; set; }

        public StackFromRecruiter()
        {
        }

        public void EditStack(string stackOne, string stackTwo, string stackThree, int recruitersId)
        {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.recruitersId = recruitersId;
        }
    }
}
