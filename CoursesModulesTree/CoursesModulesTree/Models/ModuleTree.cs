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

        //Используется вместо рекурсии при обходе графа для определения в каком месте 
        //заканчиваются и начинаются подузлы.
        public Dictionary<Module, int> numberOfSubNodesPassed;

        public void ResetNumberOfSubNodesPassed()
        {
            numberOfSubNodesPassed = new Dictionary<Module, int>();
        }
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
        public bool firstChild(Module node)
        {
            Module parent = getParent(node);
            bool isFirst = 
                (
                    node.ParentId is not null
                && adjacencyList[parent].Count == numberOfSubNodesPassed[parent]
                );
            return isFirst;
        }

        public bool lastChild(Module node)
        {
            Module parent = getParent(node);
            bool isFirst =
                (
                    node.ParentId is not null
                && numberOfSubNodesPassed[parent] == 0
                );
            return isFirst;
        }
        public void subNodePassed(Module node)
        {
            Module parent = getParent(node);
            numberOfSubNodesPassed[parent] = --numberOfSubNodesPassed[parent];
        }
    }
}
