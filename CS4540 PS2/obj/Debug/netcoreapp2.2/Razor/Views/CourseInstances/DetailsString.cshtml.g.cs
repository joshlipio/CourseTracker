#pragma checksum "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\DetailsString.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bbfffe0210b385f8602a8f28fee3b5206401570"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CourseInstances_DetailsString), @"mvc.1.0.view", @"/Views/CourseInstances/DetailsString.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CourseInstances/DetailsString.cshtml", typeof(AspNetCore.Views_CourseInstances_DetailsString))]
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
#line 1 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\_ViewImports.cshtml"
using CS4540_PS2;

#line default
#line hidden
#line 2 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\_ViewImports.cshtml"
using CS4540_PS2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbfffe0210b385f8602a8f28fee3b5206401570", @"/Views/CourseInstances/DetailsString.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ae49458cc006d5616021c937f3eb24e0eeae9e7", @"/Views/_ViewImports.cshtml")]
    public class Views_CourseInstances_DetailsString : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 443, true);
            WriteLiteral(@"<!--
  Author:    Joshua Lipio
  Date:      9/13/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
-->


");
            EndContext();
#line 12 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\DetailsString.cshtml"
  
    ViewData["Title"] = "DetailsString";

#line default
#line hidden
            BeginContext(492, 9, true);
            WriteLiteral("<p>\r\n    ");
            EndContext();
            BeginContext(502, 32, false);
#line 16 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\DetailsString.cshtml"
Write(Html.Raw(ViewData["htmlString"]));

#line default
#line hidden
            EndContext();
            BeginContext(534, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591