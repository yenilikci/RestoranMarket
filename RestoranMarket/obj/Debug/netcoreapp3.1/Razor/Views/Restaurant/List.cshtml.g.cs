#pragma checksum "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85cc89d1633c36f75123492d607c78b7436c9452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_List), @"mvc.1.0.view", @"/Views/Restaurant/List.cshtml")]
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
#line 1 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85cc89d1633c36f75123492d607c78b7436c9452", @"/Views/Restaurant/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b50886a24672e34e26feb14e82ef0a033d1a89ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurant_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RestaurantListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex justify-content-center ml-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::RestoranMarket.Infrastructure.PageLinkTagHelper __RestoranMarket_Infrastructure_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""slider-area hero-bg3 hero-overly"">
    <div class=""single-slider slider-height2 d-flex align-items-end"">
    </div>
</div>

<div class=""popular-location border-bottom section-padding40"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!-- Section Tittle -->
                <div class=""section-tittle text-center mb-80"">
                    <h2>En İyi Restoranları Keşfet!</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-8"">
                <div>
                    <h2>Toplamda ");
#nullable restore
#line 21 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
                            Write(Model.PagingInfo.TotalItems);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Restoran Bulundu</h2>\r\n                </div>\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 24 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
                     foreach (var restaurant in Model.Restaurants)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
                   Write(Html.Partial("_RestaurantItem", restaurant));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
                                                                    
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"col-lg-4\">\r\n                ");
#nullable restore
#line 31 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
           Write(await Component.InvokeAsync("CategoryMenu"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85cc89d1633c36f75123492d607c78b7436c94527567", async() => {
            }
            );
            __RestoranMarket_Infrastructure_PageLinkTagHelper = CreateTagHelper<global::RestoranMarket.Infrastructure.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__RestoranMarket_Infrastructure_PageLinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 33 "C:\Users\melih\Desktop\RestoranMarket-Commit\46- Özellik Ekleme Eklendi\RestoranMarket\Views\Restaurant\List.cshtml"
__RestoranMarket_Infrastructure_PageLinkTagHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __RestoranMarket_Infrastructure_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __RestoranMarket_Infrastructure_PageLinkTagHelper.PageAction = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RestaurantListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
