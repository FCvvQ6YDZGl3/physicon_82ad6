#pragma checksum "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0784ce20bcff490bc5ed21f7b16d1523acacb3c0"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0784ce20bcff490bc5ed21f7b16d1523acacb3c0", @"/Views/Home/Tree.cshtml")]
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
            WriteLiteral("<style>\r\n    .letter {\r\n        color: red;\r\n        font-size: 200%;\r\n    }\r\n    ol {\r\n        list-style-type: none\r\n    }\r\n</style>\r\n<div>\r\n    <h1 class=\"display-4\">Ступень 1 - Вывести на страницу данные в древовидной форме.</h1>\r\n");
#nullable restore
#line 16 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
      
        ModuleTree moduleTree = Model.moduleTree;
        foreach (Module root in moduleTree.roots)
        {
            Course course = Model.courses.Where(x => x.id == root.CourseId).FirstOrDefault();

#line default
#line hidden
#nullable disable
            WriteLiteral("            <hr />\r\n            <h2>");
#nullable restore
#line 22 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
           Write(course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <hr />\r\n");
#nullable restore
#line 24 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
            Stack<Module> stack = new Stack<Module>();
            Dictionary<Module, byte> nodes = moduleTree.adjacencyList.Keys.ToDictionary(x => x, x => (byte)0);

            stack.Push(root);

            List<Module> subNodes;
            moduleTree.ResetNumberOfSubNodesPassed();

            while (stack.Count != 0)
            {

                Module node = stack.Pop();
                nodes[node] = 2;

                Module parent = moduleTree.getParent(node);


                if (moduleTree.firstChild(node))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
               Write(Html.Raw("<ol>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                     
                }

                if (node.ParentId is not null)
                {
                    moduleTree.numberOfSubNodesPassed[parent] = --moduleTree.numberOfSubNodesPassed[parent];
                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <span class=\"letter\">");
#nullable restore
#line 52 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                    Write(node.num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> ");
#nullable restore
#line 52 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                                     Write(node.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 52 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                                                 Write(node.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 54 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"

                if (moduleTree.lastChild(node))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
               Write(Html.Raw("</ol>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\projects\physicon_82ad6\CoursesModulesTree\CoursesModulesTree\Views\Home\Tree.cshtml"
                                      
                    moduleTree.numberOfSubNodesPassed.Remove(parent);
                }

                subNodes = moduleTree.adjacencyList[node];

                if (subNodes.Count != 0)
                    moduleTree.numberOfSubNodesPassed.Add(node, subNodes.Count);

                subNodes.Reverse();
                foreach (Module item in subNodes)
                {
                    if (nodes[item] == 0)
                    {
                        stack.Push(item);
                        nodes[item] = 1;
                    }
                }
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
