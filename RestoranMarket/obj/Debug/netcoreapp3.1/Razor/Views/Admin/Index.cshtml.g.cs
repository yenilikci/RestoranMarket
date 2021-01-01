#pragma checksum "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cb2c61bbb96d1f062435ef533ddbdbd791e8129"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cb2c61bbb96d1f062435ef533ddbdbd791e8129", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9179da62a340fd73c4e5647a03d1e62975640805", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary my-2 btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


        <div class=""bg-primary text-white p-1 m-1"">
            <h2 class=""p-2"">Kullanıcı Listesi</h2>
        </div>

        <table class=""table table-bordered table-sm table-striped m-1 p-1"">
            <tr>
                <th>Kullanıcı Id</th>
                <th>Kullanıcı Adı</th>
                <th>Email</th>
            </tr>

");
#nullable restore
#line 20 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
             if (Model.Count() == 0)
	        {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t        <tr>\r\n                    <td colspan=\"3\" class=\"text-center\"> Kullanıcı Yok </td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
            }
            else
            {
                foreach (var user in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
                       Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
                       Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 35 "C:\Users\melih\source\repos\RestoranMarket\RestoranMarket\Views\Admin\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cb2c61bbb96d1f062435ef533ddbdbd791e81297131", async() => {
                WriteLiteral("Kullanıcı Oluştur");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<SharedResource> SharedLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
