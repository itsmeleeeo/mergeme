namespace MergeMe.Model
{
    public class StackFromRecruiter
    {
        public int Id { get; set; }
        public string StackOne { get; set; }
        public string StackTwo { get; set; }
        public string StackThree { get; set; }
        public Recruiter recruiters { get; set; }
        public Stacks stacks { get; set; }

        public StackFromRecruiter(string stackOne, string stackTwo, string stackThree)
        {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
        }

        public void EditStack(string stackOne, string stackTwo, string stackThree, int recruiterId, int stackId)
        {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.recruiters.Id = recruiterId;
            this.Id = stackId;
        }
    }
}
