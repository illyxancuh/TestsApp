#pragma checksum "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da1147a5dee6284e0e2cbb499c27b458247acb42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tests_Results), @"mvc.1.0.view", @"/Views/Tests/Results.cshtml")]
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
#line 1 "D:\projects\TestProj\TestProj\Views\_ViewImports.cshtml"
using TestProj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\projects\TestProj\TestProj\Views\_ViewImports.cshtml"
using TestProj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da1147a5dee6284e0e2cbb499c27b458247acb42", @"/Views/Tests/Results.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a134c4b2f47ccebf6472b86230fe07fc7d66f54c", @"/Views/_ViewImports.cshtml")]
    public class Views_Tests_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestProj.Models.TestPassedModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Test \'");
#nullable restore
#line 3 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
     Write(Model.TestSummary.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' finished on ");
#nullable restore
#line 3 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
                                          Write(Model.CompletionTime.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h2>\r\n<img");
            BeginWriteAttribute("src", " src=\"", 133, "\"", 166, 1);
#nullable restore
#line 4 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
WriteAttributeValue("", 139, Model.TestSummary.ImageUrl, 139, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"border: 1px solid black; max-width: 256px; max-height: 256px;\" alt=\"Test cover image\"/>\r\n<h3><b>Your result:</b> ");
#nullable restore
#line 5 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
                    Write(Model.Score.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</h3>\r\n\r\n");
#nullable restore
#line 7 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
 if(@Model.IsPassed)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<h3 style=\"color: green;\">PASSED!</h3>\r\n");
#nullable restore
#line 10 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<h3 style=\"color: darkred;\">Try again.</h3>\r\n");
#nullable restore
#line 14 "D:\projects\TestProj\TestProj\Views\Tests\Results.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a href=\"/home\" class=\"btn btn-primary\" role=\"button\" aria-disabled=\"true\">Back</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestProj.Models.TestPassedModel> Html { get; private set; }
    }
}
#pragma warning restore 1591