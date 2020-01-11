#pragma checksum "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f356748900817cb869102521f35905e87e36818"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CourseInstances_InstructorCourses), @"mvc.1.0.view", @"/Views/CourseInstances/InstructorCourses.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CourseInstances/InstructorCourses.cshtml", typeof(AspNetCore.Views_CourseInstances_InstructorCourses))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f356748900817cb869102521f35905e87e36818", @"/Views/CourseInstances/InstructorCourses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ae49458cc006d5616021c937f3eb24e0eeae9e7", @"/Views/_ViewImports.cshtml")]
    public class Views_CourseInstances_InstructorCourses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CS4540_PS2.Models.CourseInstance>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailsString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 443, true);
            WriteLiteral(@"<!--
  Author:    Joshua Lipio
  Date:      9/27/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
-->


");
            EndContext();
            BeginContext(497, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
  
    ViewData["Title"] = "Instructor Courses";

#line default
#line hidden
            BeginContext(553, 196, true);
            WriteLiteral("\r\n<div>\r\n    <p class=\"display-4 container\"> Your Courses </p>\r\n</div>\r\n\r\n<table class=\"table bg-light\">\r\n    <thead class=\"bg-danger text-white\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(750, 38, false);
#line 26 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
           Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
            EndContext();
            BeginContext(788, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(844, 42, false);
#line 29 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
           Write(Html.DisplayNameFor(model => model.Number));

#line default
#line hidden
            EndContext();
            BeginContext(886, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(942, 40, false);
#line 32 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(982, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1038, 45, false);
#line 35 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
           Write(Html.DisplayNameFor(model => model.Professor));

#line default
#line hidden
            EndContext();
            BeginContext(1083, 163, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Progress\r\n            </th>\r\n            <th>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 45 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1295, 60, true);
            WriteLiteral("            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1356, 37, false);
#line 49 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
               Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
            EndContext();
            BeginContext(1393, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1460, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f356748900817cb869102521f35905e87e368187681", async() => {
                BeginContext(1515, 41, false);
#line 52 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.Number));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                                    WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1560, 51, true);
            WriteLiteral("\r\n</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1611, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f356748900817cb869102521f35905e87e3681810314", async() => {
                BeginContext(1660, 39, false);
#line 55 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                              WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1703, 152, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <!--Link to a dummy professor page-->\r\n                    <a href=\"/Home/Professor\">");
            EndContext();
            BeginContext(1856, 44, false);
#line 59 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                         Write(Html.DisplayFor(modelItem => item.Professor));

#line default
#line hidden
            EndContext();
            BeginContext(1900, 119, true);
            WriteLiteral("</a>\r\n                </td>\r\n                <td>\r\n                    <!--Generate random number for Progress bar-->\r\n");
            EndContext();
#line 63 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                      
                        var r = new Random();
                        int s = r.Next(100);
                    

#line default
#line hidden
            BeginContext(2159, 112, true);
            WriteLiteral("                    <div class=\"progress\">\r\n                        <div class=\"progress-bar\" role=\"progressbar\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2271, "\"", 2290, 3);
            WriteAttributeValue("", 2279, "width:", 2279, 6, true);
#line 68 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
WriteAttributeValue(" ", 2285, s, 2286, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 2288, "%;", 2288, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("aria-valuenow", " aria-valuenow=\"", 2291, "\"", 2309, 1);
#line 68 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
WriteAttributeValue("", 2307, s, 2307, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2310, 39, true);
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\">");
            EndContext();
            BeginContext(2350, 1, false);
#line 68 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
                                                                                                                                             Write(s);

#line default
#line hidden
            EndContext();
            BeginContext(2351, 79, true);
            WriteLiteral("%</div>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 72 "C:\Users\Lipio\Source\Repos\CS4540 PS2\CS4540 PS2\Views\CourseInstances\InstructorCourses.cshtml"
        }

#line default
#line hidden
            BeginContext(2441, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CS4540_PS2.Models.CourseInstance>> Html { get; private set; }
    }
}
#pragma warning restore 1591