#pragma checksum "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5157d9619848219bb2a7846f915f97dc439682d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_OrdersOfRest), @"mvc.1.0.view", @"/Views/Admin/OrdersOfRest.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5157d9619848219bb2a7846f915f97dc439682d", @"/Views/Admin/OrdersOfRest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"816295f6cc3d845ede529d42204e4c3fa38a6ad7", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_OrdersOfRest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OtlobProject.ModelViews.innerorder>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
  
    ViewData["Title"] = "OrdersOfRest";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h1 style=\"text-align:center;font-size:30px ;color: #3d9970;font-family: cursive;\">Order No : ");
#nullable restore
#line 7 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
                                                                                             Write(ViewBag.ordid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Name\r\n            </th>\r\n            <th>\r\n                Quantity\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 24 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
           Write(Html.DisplayFor(modelItem => item.Meal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 27 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 31 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<div>\r\n    ");
#nullable restore
#line 36 "C:\Users\merna\Downloads\OtlobProject\OtlobProject\Views\Admin\OrdersOfRest.cshtml"
Write(Html.ActionLink("Back", "OrderList",null,htmlAttributes: new { @class="btn btn-secondary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OtlobProject.ModelViews.innerorder>> Html { get; private set; }
    }
}
#pragma warning restore 1591
