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
    }
}
