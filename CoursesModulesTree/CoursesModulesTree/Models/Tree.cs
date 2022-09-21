using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesModulesTree.Models
{
    public class Tree
    {
        public HashSet<Course> courses;
        public ModuleTree moduleTree;

        public string subject { get; set; }
        public int grade { get; set; }
        public string genre { get; set; }
    }
}