using CoursesModulesTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesModulesTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IModuleRepository ModuleRepository;
        public HomeController(ILogger<HomeController> logger, IModuleRepository moduleRepository)
        {
            _logger = logger;
            this.ModuleRepository = moduleRepository;

        }

        public IActionResult Tree()
        {
            
            List<Module> modules = ModuleRepository.GetModules();
            Dictionary<Module, List<Module>> adjacencyList = new Dictionary<Module,List<Module>>();
            foreach (Module item in modules)
            {
                adjacencyList.Add(item, modules.Where(modules => modules.ParentId == item.Id).ToList());
            }
            ModuleTree moduleTree = new ModuleTree();
            moduleTree.adjacencyList = adjacencyList;
            moduleTree.roots = modules.Where(modules => modules.ParentId is null).ToHashSet();
            return View(moduleTree);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}