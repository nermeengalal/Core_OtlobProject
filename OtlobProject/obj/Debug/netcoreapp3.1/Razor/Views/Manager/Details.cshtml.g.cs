#pragma checksum "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a14f880cb36a39e0731562bea8fb41d0f8ec3312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Details), @"mvc.1.0.view", @"/Views/Manager/Details.cshtml")]
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
#line 1 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\_ViewImports.cshtml"
using OtlobProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\_ViewImports.cshtml"
using OtlobProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a14f880cb36a39e0731562bea8fb41d0f8ec3312", @"/Views/Manager/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"816295f6cc3d845ede529d42204e4c3fa38a6ad7", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OtlobProject.Models.Restaurant>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Card image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100% ;height:300px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"card\" style=\"width:600px\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a14f880cb36a39e0731562bea8fb41d0f8ec33124535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 217, "~/images/", 217, 9, true);
#nullable restore
#line 9 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
AddHtmlAttributeValue("", 226, Model.Logo, 226, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <div class=\"card-body\">\r\n            <h1 style=\"text-align:center;font-size:30px ;color: #3d9970;font-family: cursive;\">");
#nullable restore
#line 11 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                                                                                          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <table class=\"table table-striped\">\r\n                <tr>\r\n                    <th>Mobile : </th>\r\n                    <td>");
#nullable restore
#line 15 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                   \r\n                </tr>\r\n                <tr>\r\n                    <th>HotLine :</th>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.HotLine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th>Max Estimated DeliveryTime :</th>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.MaxEstimatedDeliveryTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n                </tr>\r\n                <tr>\r\n                    <th>Working From :</th>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.WorkingFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n                </tr>\r\n                <tr>\r\n                    <th>Working To : </th>\r\n                    <td>");
#nullable restore
#line 34 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.WorkingTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                   \r\n                </tr>\r\n                <tr>\r\n                    <th>Delivery Fee : </th>\r\n                    <td>");
#nullable restore
#line 39 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(Model.DeliveryFee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                   \r\n                </tr>\r\n                <tr>\r\n                    <th>Area : </th>\r\n                    <td>");
#nullable restore
#line 44 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Manager\Details.cshtml"
                   Write(ViewBag.area);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                  
                </tr>
                

            </table>
            <div style=""text-align:center"">
                <a href=""/Manager/Index"" class=""btn btn-secondary btn-sm stretched-link"" style=""text-align:center"">Back</a>
            </div>
        </div>
    </div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OtlobProject.Models.Restaurant> Html { get; private set; }
    }
}
#pragma warning restore 1591
