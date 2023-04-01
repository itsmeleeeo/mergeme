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

        

        public void EditStack(string stackOne, string stackTwo, string stackThree, int recruiterId)
        {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.recruiters.Id = recruiterId;
        }
    }
}
