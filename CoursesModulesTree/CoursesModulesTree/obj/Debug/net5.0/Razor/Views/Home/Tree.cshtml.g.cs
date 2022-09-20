#pragma checksum "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "663c20a3dbaac7ded954592a654832f4db5d230f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Tree), @"mvc.1.0.view", @"/Views/Home/Tree.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\_ViewImports.cshtml"
using CoursesModulesTree;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\_ViewImports.cshtml"
using CoursesModulesTree.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"663c20a3dbaac7ded954592a654832f4db5d230f", @"/Views/Home/Tree.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1e2b3ea4b440419dcee54ed1987cc9dc432ee88", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Tree : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tree>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .letter {\r\n        color: red; /* Цвет символа */\r\n        font-size: 200%; /* Размер шрифта */\r\n    }\r\n</style>\r\n<div>\r\n    <h1 class=\"display-4\">Ступень 1 - Вывести на страницу данные в древовидной форме.</h1>\r\n");
#nullable restore
#line 13 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
      
        ModuleTree moduleTree = Model.moduleTree;
        foreach (Module root in moduleTree.roots)
        {
            Course course = Model.courses.Where(x => x.id == root.CourseId).FirstOrDefault();

#line default
#line hidden
#nullable disable
            WriteLiteral("            <hr />\r\n            <h2>");
#nullable restore
#line 19 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
           Write(course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <hr />\r\n");
#nullable restore
#line 21 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
            Queue<Module> queue = new Queue<Module>();
            Dictionary<Module, byte> nodes = moduleTree.adjacencyList.Keys.ToDictionary(x => x, x => (byte)0);

            queue.Enqueue(root);

            List<Module> subNodes;

            int numberOfPassedSubNodes;

            int numberOfNodesPassed = 0;
            
            while (queue.Count != 0)
            {

                Module node = queue.Dequeue();
                nodes[node] = 2;
                numberOfNodesPassed++;

                subNodes = moduleTree.adjacencyList[node];
                foreach (Module item in subNodes)
                {
                    if (nodes[item] == 0)
                    {
                        queue.Enqueue(item);
                        nodes[item] = 1;
                    }

                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><span class=\"letter\">");
#nullable restore
#line 50 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                    Write(node.num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> ");
#nullable restore
#line 50 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                                     Write(node.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                                                 Write(node.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 51 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tree> Html { get; private set; }
    }
}
#pragma warning restore 1591
