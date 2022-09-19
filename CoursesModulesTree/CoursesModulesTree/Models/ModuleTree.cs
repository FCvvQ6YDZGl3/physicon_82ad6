using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesModulesTree.Models
{
    public class ModuleTree
    {
        public HashSet<Module> roots;
        public Dictionary<Module, List<Module>> adjacencyList;
    }
}
