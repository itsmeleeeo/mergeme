namespace MergeMe.Model
{
    public class StackFromDeveloper
    {
        public int Id { get; set; }
        public string StackOne { get; set; }
        public string StackTwo { get; set; }
        public string StackThree { get; set; }
        public Developer developers { get; set; }
        public Stacks stacks { get; set; }

        public StackFromDeveloper(string stackOne, string stackTwo, string stackThree, int developerId)
        {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.developers.Id = developerId;
        }

        public void EditStack(string stackOne, string stackTwo, string stackThree, int developerId) {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.developers.Id = developerId;
        }
    }
}
