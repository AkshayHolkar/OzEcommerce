#pragma checksum "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3754d64b04aa407c6ff063ae32f0a36ead25cb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
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
#line 1 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\_ViewImports.cshtml"
using OzEcommerceV14;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\_ViewImports.cshtml"
using OzEcommerceV14.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3754d64b04aa407c6ff063ae32f0a36ead25cb6", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a19b977e1dc828a23b2787b49170397d3baf764", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OzEcommerceV14.Models.ViewModels.OrderViewModels.OrderSuccessViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-classic"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
  
    Layout = "../Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-body"">
    <!-- Container-fluid starts-->
    <div class=""container-fluid"">
        <div class=""page-header"">
            <div class=""row"">
                <div class=""col-lg-6"">
                    <div class=""page-header-left"">
                        <h3>
                            Profile
                        </h3>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <ol class=""breadcrumb pull-right"">

                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!-- Container-fluid Ends-->
    <!-- Container-fluid starts-->
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-xl-4 col-md-6 xl-50"">
                <div class=""card o-hidden widget-cards"">
                    <div class=""bg-warning card-body"">
                        <div class=""media static-top-widget row"">
                            <div class=""icons-widgets col");
            WriteLiteral(@"-4"">
                                <div class=""align-self-center text-center""><i data-feather=""navigation""
                                        class=""font-warning""></i>
                                </div>
                            </div>
                            <div class=""media-body col-8"">
                                <span class=""m-0"">Unread Messages</span>
                                <h3 class=""mb-0""><span class=""counter"">");
#nullable restore
#line 44 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                                  Write(ViewBag.Messages);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-4"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""profile-details text-center"">
");
#nullable restore
#line 54 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                             if (Model.Account != null)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h5 class=\"f-w-600 mb-0\">");
#nullable restore
#line 57 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                    Write(Model.Account.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <span>");
#nullable restore
#line 58 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                 Write(Model.Account.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 59 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                            }
                            else
                            {
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>

                        <hr>

                    </div>
                </div>
            </div>
            <div class=""col-xl-8"">
                <div class=""card tab2-card"">
                    <div class=""card-body"">
                        <ul class=""nav nav-tabs nav-material"" id=""top-tab"" role=""tablist"">
                            <li class=""nav-item"">
                                <a class=""nav-link active"" id=""top-profile-tab"" data-toggle=""tab"" href=""#top-profile""
                                    role=""tab"" aria-controls=""top-profile"" aria-selected=""true""><i data-feather=""user""
                                        class=""mr-2""></i>Profile</a>
                            </li>
                        </ul>
                        <div class=""tab-content"" id=""top-tabContent"">
                            <div class=""tab-pane fade show active"" id=""top-profile"" role=""tabpanel""
                                aria-labelledby=""top-profile-tab"">
 ");
            WriteLiteral(@"                               <h5 class=""f-w-600"">Profile</h5>
                                <div class=""table-responsive profile-table"">
                                    <table class=""table table-responsive"">
                                        <tbody>
");
#nullable restore
#line 87 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                             if (Model.Account != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>Full Name:</td>\r\n                                                    <td>");
#nullable restore
#line 91 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Account.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
            WriteLiteral("                                                <tr>\r\n                                                    <td>Email:</td>\r\n                                                    <td>");
#nullable restore
#line 96 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Account.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
            WriteLiteral("                                                <tr>\r\n                                                    <td>Contact Number:</td>\r\n                                                    <td>");
#nullable restore
#line 101 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Account.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3754d64b04aa407c6ff063ae32f0a36ead25cb612382", async() => {
                WriteLiteral("Edit Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 109 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3754d64b04aa407c6ff063ae32f0a36ead25cb614652", async() => {
                WriteLiteral("Add detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 118 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                             if (Model.Address != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>Shipping Address:</td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 124 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Address.Property);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                                                        ");
#nullable restore
#line 125 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Address.StreetName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                                                        ");
#nullable restore
#line 126 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 126 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                                       Write(Model.Address.Postcode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                                                        ");
#nullable restore
#line 127 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                   Write(Model.Address.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 127 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                                                        Write(Model.Address.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3754d64b04aa407c6ff063ae32f0a36ead25cb619318", async() => {
                WriteLiteral("Edit Address");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 136 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3754d64b04aa407c6ff063ae32f0a36ead25cb621589", async() => {
                WriteLiteral("Add Address");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 145 "D:\OzEcommerce\OzEcommerceV14\OzEcommerceV14\Views\Customer\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Container-fluid Ends-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OzEcommerceV14.Models.ViewModels.OrderViewModels.OrderSuccessViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591