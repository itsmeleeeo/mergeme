namespace MergeMe.Model
{
    public class StackFromDeveloper
    {
        public int Id { get; set; }

        public Developer developers { get; set; }
        public Stacks stacks { get; set; }
    }
}
