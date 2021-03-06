#pragma checksum "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12b2c5f6e5dfdf374f8fccfed08d6e490f74a294"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_OrderDetail), @"mvc.1.0.view", @"/Views/Customer/OrderDetail.cshtml")]
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
#line 1 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\_ViewImports.cshtml"
using OzEcommerceV14;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\_ViewImports.cshtml"
using OzEcommerceV14.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b2c5f6e5dfdf374f8fccfed08d6e490f74a294", @"/Views/Customer/OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a19b977e1dc828a23b2787b49170397d3baf764", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OzEcommerceV14.Models.ViewModels.CustomerViewModel.OrderDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SendMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-classic"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
  
    Layout = "../Shared/_CustomerLayout.cshtml";
    double total = 0;
    double shippingCharges = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--section start-->
<section class=""section-b-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <h4>Order Detail:</h4>
                <table class=""table cart-table table-responsive-xs"">
                    <thead>
                        <tr class=""table-head"">
                            <th scope=""col"">product name</th>
                            <th scope=""col"">quantity</th>
                            <th scope=""col"">total</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 26 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                         foreach (var product in Model.OrderDetail)
                        {
                            shippingCharges = product.ShippingCharge;

                            total += product.TotalPrice;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b2c5f6e5dfdf374f8fccfed08d6e490f74a2946487", async() => {
#nullable restore
#line 33 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                                                                                                 Write(product.ProductName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                                                                      WriteLiteral(product.ProductId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("<br />\r\n");
#nullable restore
#line 34 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                 if (product.Size != null)
                                {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                           Write(product.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 37 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                 if(product.Color != null) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <ul class=\"color-variant\"><li");
            BeginWriteAttribute("style", " style=\"", 1644, "\"", 1684, 2);
            WriteAttributeValue("", 1652, "background-color:", 1652, 17, true);
#nullable restore
#line 39 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
WriteAttributeValue(" ", 1669, product.Color, 1670, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> </li></ul>");
#nullable restore
#line 39 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                                                                                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                               Write(product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 41 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                 if (product.OriginalTotal > product.TotalPrice)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 43 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                   Write(product.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("<del>");
#nullable restore
#line 43 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                                           Write(product.OriginalTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</del></td>\r\n");
#nullable restore
#line 44 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 47 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                   Write(product.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 48 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tr>\r\n");
#nullable restore
#line 52 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n                <table class=\"table cart-table table-responsive-md\">\r\n                    <tfoot>\r\n");
#nullable restore
#line 59 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                         if (shippingCharges != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>Shipping Charges :</td>\r\n                                <td>\r\n                                    <h2>$");
#nullable restore
#line 64 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                    Write(shippingCharges);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>total price :</td>\r\n                            <td>\r\n                                <h2>$");
#nullable restore
#line 71 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                 Write(total + shippingCharges);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            </td>\r\n                        </tr>\r\n                    </tfoot>\r\n                </table>\r\n                <br />\r\n");
#nullable restore
#line 77 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                 if (Model.TrackingNumber != null && Model.CompanyName != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <h4>Shipping Detail: </h4>
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th scope=""col"">Shipping company name</th>
                                <th scope=""col"">Tracking no</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>


                              
                                    <td>");
#nullable restore
#line 92 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                   Write(Model.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 93 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                   Write(Model.TrackingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    \r\n                               \r\n\r\n                            </tr>\r\n\r\n                        </tbody>\r\n\r\n                    </table>\r\n");
#nullable restore
#line 102 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n        </div>\r\n        <div class=\"row cart-buttons\">\r\n            <div class=\"col-6\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b2c5f6e5dfdf374f8fccfed08d6e490f74a29417274", async() => {
                WriteLiteral("Message Seller");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 106 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Customer\OrderDetail.cshtml"
                                                                                       WriteLiteral(Model.OrderId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n            <div class=\"col-6\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b2c5f6e5dfdf374f8fccfed08d6e490f74a29419828", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!--section end-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OzEcommerceV14.Models.ViewModels.CustomerViewModel.OrderDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
