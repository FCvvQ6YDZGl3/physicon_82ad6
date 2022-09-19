namespace CoursesModulesTree.Models
{
    public class Module
    {
        public int ?ParentId { get; set; }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string num { get; set; }
    }
}
