namespace MergeMe.Model
{
    public class StackFromDeveloper
    {
        public int Id { get; set; }
        public string StackOne { get; set; }
        public string StackTwo { get; set; }
        public string StackThree { get; set; }
        public Developer developers { get; set; }
        public int developersId { get; set; }
        
        public StackFromDeveloper()
        {
        }

        public void EditStack(string stackOne, string stackTwo, string stackThree, int developersId) {
            this.StackOne = stackOne;
            this.StackTwo = stackTwo;
            this.StackThree = stackThree;
            this.developersId = developersId;
        }
    }
}
