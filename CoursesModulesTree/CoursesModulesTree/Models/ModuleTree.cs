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

        public int getLevel(Module module)
        {
            Module parentModule;
            int level = 1;
            parentModule = module;
            while (parentModule.ParentId is not null)
            {
                level++;
                parentModule = getParent(parentModule);
            }
            return level;
        }
        public Module getParent(Module module)
        {
            Module parentModule = null;
            parentModule = adjacencyList.Keys.Where(x => (x.Id == module.ParentId)).FirstOrDefault();
            return parentModule;
        }
    }
}
