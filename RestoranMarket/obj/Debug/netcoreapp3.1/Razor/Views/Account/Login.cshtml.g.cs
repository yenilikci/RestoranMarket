#pragma checksum "C:\Users\melih\RestoranMarket\RestoranMarket\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9228618de55d76c60072ef735bf87fe619fe920e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
#line 1 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\melih\RestoranMarket\RestoranMarket\Views\_ViewImports.cshtml"
using RestoranMarket.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9228618de55d76c60072ef735bf87fe619fe920e", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9179da62a340fd73c4e5647a03d1e62975640805", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-contact contact_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("contact_process.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contactForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("novalidate", new global::Microsoft.AspNetCore.Html.HtmlString("novalidate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--? Hero Area Start-->
<div class=""slider-area hero-bg3 hero-overly"">
    <div class=""single-slider slider-height2 d-flex align-items-end"">
        <div class=""container"">
            <div class=""directory-details-head"">
                <section class=""wantToWork-area"">
                    <div class=""wants-wrapper w-padding3"">
                        <div class=""row align-items-center justify-content-between"">
                            <div class=""col-xl-8"">
                                <div class=""details-cap d-flex"">
                                    <div class=""properties__caption"">
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</div>

<section class=""contact-section"">
    <div class=""container"">
        <div class=""row"">
            ");
            WriteLiteral("<div class=\"col-12\">\r\n                <h1 class=\"contact-title text-center\">Giriş Yap</h1>\r\n            </div>\r\n            <div class=\"col-lg-3\"></div>\r\n            <div class=\"col-lg-6\">\r\n                <hr />\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9228618de55d76c60072ef735bf87fe619fe920e7134", async() => {
                WriteLiteral(@"
                    <div class=""row"">

                        <div class=""col-sm-12"">
                            <h3>Mail Adresi:</h3>
                            <div class=""form-group border"">
                                <input class=""form-control valid"" type=""email"" placeholder=""Mail Adresinizi Giriniz"">
                            </div>
                        </div>
                        <div class=""col-sm-12"">
                            <h3>Şifre:</h3>
                            <div class=""form-group border"">
                                <input class=""form-control valid"" type=""password"" placeholder=""Şifrenizi Giriniz"">
                            </div>
                        </div>

                    </div>
                    <div class=""form-group d-flex justify-content-sm-around align-items-center mt-3"">
                        <button type=""submit"" class=""mx-1 button button-contactForm boxed-btn"">KAYIT OL</button>
                        <button type=""submit"" c");
                WriteLiteral("lass=\"mx-1 button button-contactForm boxed-btn\">GİRİŞ YAP</button>\r\n\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-lg-3\"></div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
