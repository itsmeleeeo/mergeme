
namespace MergeMe.Model
{
    public class Stacks
    {
        public int Id { get; set; }
        public string StackName { get; set; }
        public string ImageUrl { get; set; }

        public List<Developer> developers { get; set; }
        public List<Recruiter> recruiters { get; set; }
    }
}
