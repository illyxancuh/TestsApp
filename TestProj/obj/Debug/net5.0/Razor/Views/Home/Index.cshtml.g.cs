#pragma checksum "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcfcf2b5d11d9461a0772101b591f61de8b7368c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\_ViewImports.cshtml"
using TestProj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\_ViewImports.cshtml"
using TestProj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcfcf2b5d11d9461a0772101b591f61de8b7368c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a134c4b2f47ccebf6472b86230fe07fc7d66f54c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestProj.Models.TestSummaryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n</div>\r\n<div>\r\n\r\n    <h3>Hello, ");
#nullable restore
#line 12 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h3>\r\n    <hr />\r\n\r\n    <div>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
         if (Model != null && Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
             foreach (TestSummaryModel testSummary in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\" style=\"width: 18rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 453, "\"", 480, 1);
#nullable restore
#line 22 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
WriteAttributeValue("", 459, testSummary.ImageUrl, 459, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 24 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
                                          Write(testSummary.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 647, "\"", 675, 2);
            WriteAttributeValue("", 654, "tests/", 654, 6, true);
#nullable restore
#line 25 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
WriteAttributeValue("", 660, testSummary.Id, 660, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Start</a>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-info\" role=\"alert\">\r\n                You have no tests yet.\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\Expert\source\repos\TestProj\TestProj\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>

</div>

<style>
    h2 {
        font-size: larger;
    }

    .test {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        background-color: darkgrey;
        padding-left: 10px;
        padding-right: 10px;
        padding-top: 5px;
        padding-bottom: 5px;
        border-radius: 20px 5px 5px 20px;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestProj.Models.TestSummaryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
