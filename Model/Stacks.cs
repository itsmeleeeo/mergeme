
namespace MergeMe.Model
{
    public class Stacks
    {
        public int id { get; set; }
        public string StackName { get; set; }

        public List<Developer> developers { get; set; }
        public List<Recruiter> recruiters { get; set; }
    }
}
