#pragma checksum "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "789199bd049689b74d24cfe5b1112650fd477362"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SparkAuto.Pages.Services.Pages_Services_History), @"mvc.1.0.razor-page", @"/Pages/Services/History.cshtml")]
namespace SparkAuto.Pages.Services
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
#line 1 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\_ViewImports.cshtml"
using SparkAuto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\_ViewImports.cshtml"
using SparkAuto.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"789199bd049689b74d24cfe5b1112650fd477362", @"/Pages/Services/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47c6e9be6d81a789d3680fae9ed89376b343ede", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Services_History : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../Cars/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
  
    ViewData["Title"] = "History";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container row pt-4 pb-2\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info py-2\">Service History</h2>\r\n    </div>\r\n    <div class=\"col-3 offset-3 text-right py-2\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "789199bd049689b74d24cfe5b1112650fd4773625068", async() => {
                WriteLiteral("\r\n            Back to Cars\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                          WriteLiteral(Model.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 20 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
 if (Model.ServiceHeaderList.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container whitebackground"">
        <div class=""card"">
            <div class=""card-header bg-dark text-light ml-0 row container"">
                <div class=""col-1 text-center pt-3 text-white-50"">
                    <i class=""far fa-user fa-2x""></i>
                </div>
                <div class=""col-5"">
                    <p>");
#nullable restore
#line 29 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                  Write(Model.ServiceHeader.Car.ApplicationUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 30 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                  Write(Model.ServiceHeader.Car.ApplicationUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("                </div>\r\n                <div class=\"col-5 text-right\">\r\n                    <p>");
#nullable restore
#line 34 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                  Write(Model.ServiceHeader.Car.Colour);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                                  Write(Model.ServiceHeader.Car.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                                                                Write(Model.ServiceHeader.Car.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                                                                                               Write(Model.ServiceHeader.Car.Style);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 35 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                  Write(Model.ServiceHeader.Car.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral(@"                </div>
                <div class=""col-1 text-right pt-3 text-white-50"">
                    <i class=""fas fa-car fa-2x""></i>
                </div>
            </div>
            <div class=""card-body"">
                <div class=""container"">
                    <div class=""border rounded p-2"">

                        <table class=""table table-striped border"">
                            <tr class=""table-secondary"">
                                <th>");
#nullable restore
#line 48 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                               Write(Html.DisplayNameFor(n => n.ServiceHeader.Miles));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 49 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                               Write(Html.DisplayNameFor(n => n.ServiceHeader.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 50 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                               Write(Html.DisplayNameFor(n => n.ServiceHeader.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 51 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                               Write(Html.DisplayNameFor(n => n.ServiceHeader.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th></th>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                             foreach (var service in Model.ServiceHeaderList)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 58 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                   Write(Html.DisplayFor(n => service.Miles));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 59 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                   Write(Html.DisplayFor(n => service.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 60 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                   Write(Html.DisplayFor(n => service.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 61 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                   Write(Html.Raw(service.DateAdded.ToString("d")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "789199bd049689b74d24cfe5b1112650fd47736213702", async() => {
                WriteLiteral("\r\n                                            <i class=\"fas fa-list\"></i> Details\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-serviceHeaderId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                                                                             WriteLiteral(service.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceHeaderId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-serviceHeaderId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceHeaderId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 68 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
#nullable restore
#line 76 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
          }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"whitebackground\">\r\n        <p class=\"text-danger\">No service history found..</p>\r\n    </div>\r\n");
#nullable restore
#line 82 "C:\Users\genag\OneDrive\Desktop\GarageService\Pages\Services\History.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SparkAuto.Pages.Services.HistoryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SparkAuto.Pages.Services.HistoryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SparkAuto.Pages.Services.HistoryModel>)PageContext?.ViewData;
        public SparkAuto.Pages.Services.HistoryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
