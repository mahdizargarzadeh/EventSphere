#pragma checksum "D:\Old project\Mqeb Project\Mqeb\Mqeb.Web\Views\Home\AboutUs.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5b13f1640bb35e9cbce88ec736ba13c878a68975fbaa5167e24bc6cccd6ca961"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AboutUs), @"mvc.1.0.view", @"/Views/Home/AboutUs.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Old project\Mqeb Project\Mqeb\Mqeb.Web\Views\_ViewImports.cshtml"
using Mqeb.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Old project\Mqeb Project\Mqeb\Mqeb.Web\Views\_ViewImports.cshtml"
using Mqeb.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5b13f1640bb35e9cbce88ec736ba13c878a68975fbaa5167e24bc6cccd6ca961", @"/Views/Home/AboutUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"c2b61ae8b0360fd438507fa4acb342772d61cf74fab9e051d260bf0266b485c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_AboutUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mqeb.Domain.Models.Home.AboutUs>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Old project\Mqeb Project\Mqeb\Mqeb.Web\Views\Home\AboutUs.cshtml"
  
    ViewData["Title"] = "درباره موسسه";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("MetaTags", async() => {
                WriteLiteral("\r\n    <meta name=\"googlebot\" content=\"index,follow\">\r\n    <meta name=\"robots\" content=\"noodp,noydir\">\r\n");
            }
            );
            WriteLiteral(@"
<section class=""container mb-2 mt-4"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""breadcrumb radius15 shadow-sm"">
                <ul>
                    <li><a href=""/"">خانه / </a></li>
                    <li><a href=""/AboutUs"" class=""current"">درباره موسسه</a></li>
                </ul>
            </div>
        </div>
    </div>
</section>
<section class=""container mb-4"">
    <div class=""row"">
        <div class=""col-xl-12  mb-3"">
            <div class=""card  mb-4"">
                <div class=""card-header"">
                    <h2>درباره موسسه</h2>
                </div>
                <div class=""card-body  p-md-4"">
                    ");
#nullable restore
#line 32 "D:\Old project\Mqeb Project\Mqeb\Mqeb.Web\Views\Home\AboutUs.cshtml"
               Write(Html.Raw(Model.AboutDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mqeb.Domain.Models.Home.AboutUs> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
