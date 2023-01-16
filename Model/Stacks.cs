
namespace MergeMe.Model
{
    public class Stacks
    {
        public int Id { get; set; }
        public string StackName { get; set; }

        public List<Developer> developers { get; set; }
        public List<Recruiter> recruiters { get; set; }
    }
}
