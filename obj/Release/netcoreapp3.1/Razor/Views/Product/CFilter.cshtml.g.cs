#pragma checksum "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f53ea4abb85f84e0901ca9aefb28d48f828e2ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_CFilter), @"mvc.1.0.view", @"/Views/Product/CFilter.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f53ea4abb85f84e0901ca9aefb28d48f828e2ac", @"/Views/Product/CFilter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a19b977e1dc828a23b2787b49170397d3baf764", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_CFilter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OzEcommerceV14.Models.ViewModels.ComboSetViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid blur-up lazyload"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddBundle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
  
    ViewData["Title"] = "Combo Recommondations";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<section class=""section-b-space ratio_asos"">
    <div class=""collection-wrapper"">
        <div class=""container"">
            <div class=""row"">
                <div class=""collection-content col"">
                    <div class=""page-main-content"">
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <div class=""collection-product-wrapper"">
                                    <div class=""product-top-filter"">
                                        <div class=""row"">
                                            <div class=""col-12"">
                                                <div class=""popup-filter"">
                                                    <div class=""dropdown"">
                                                        <button type=""button"" class=""btn btn-primary dropdown-toggle"" data-toggle=""dropdown"">
                                                            Filter by LifeStyle
                        ");
            WriteLiteral("                                </button>\r\n                                                        <div class=\"dropdown-menu\">\r\n");
#nullable restore
#line 28 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                             foreach (var category in ViewBag.categories)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f53ea4abb85f84e0901ca9aefb28d48f828e2ac8336", async() => {
#nullable restore
#line 30 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                                                                                                                                                     Write(category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                                                                                         WriteLiteral(category.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                                                                                                                          WriteLiteral(Model.LifeStyleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["comboId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-comboId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["comboId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 31 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </div>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""product-wrapper-grid product-load-more"">
                                        <div class=""row"">

");
#nullable restore
#line 44 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                             foreach (var combo in Model.comboSet)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f53ea4abb85f84e0901ca9aefb28d48f828e2ac13221", async() => {
                WriteLiteral(@"

                                                    <div class=""col-xl-4 col-md-6 col-grid-box"">
                                                        <div class=""bundle"">
                                                            <div class=""bundle_img"">
");
#nullable restore
#line 51 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                  
                                                                    int count = combo.Combo.Count();
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                 foreach (var product in combo.Combo)
                                                                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    <div class=\"img-box\">\r\n                                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f53ea4abb85f84e0901ca9aefb28d48f828e2ac14697", async() => {
                    WriteLiteral("\r\n                                                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4f53ea4abb85f84e0901ca9aefb28d48f828e2ac15037", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    AddHtmlAttributeValue("", 3579, "~/productimages/", 3579, 16, true);
#nullable restore
#line 59 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
AddHtmlAttributeValue("", 3595, product.Image, 3595, 14, false);

#line default
#line hidden
#nullable disable
                    EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                                                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
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
                WriteLiteral("\r\n                                                                    </div>\r\n");
#nullable restore
#line 63 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                    count--;
                                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                     if (count > 0)
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <span class=\"plus\">+</span>\r\n");
#nullable restore
#line 67 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                     
                                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            </div>\r\n                                                            <div class=\"bundle_detail\">\r\n                                                                <div class=\"theme_checkbox\">\r\n");
#nullable restore
#line 72 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                     foreach (var product in combo.Combo)
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <label>\r\n                                                                            ");
#nullable restore
#line 75 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                       Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span class=\"price_product\">$");
#nullable restore
#line 75 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                                                                  Write(product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n\r\n                                                                        </label>\r\n");
#nullable restore
#line 78 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"

                                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                </div>\r\n                                                            </div>\r\n                                                            <h4><del>$");
#nullable restore
#line 82 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                                 Write(combo.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral("</del></h4>\r\n                                                            <h3>$");
#nullable restore
#line 83 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                                            Write(combo.DiscountTotal);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                                                            <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 5590, "\"", 5612, 1);
#nullable restore
#line 84 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
WriteAttributeValue("", 5598, combo.ComboId, 5598, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                                            <button class=""btn btn-solid btn-xs"" type=""submit"">buy this bundle</button>
                                                        </div>
                                                    </div>
                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 89 "C:\Users\Akshay\source\repos\OzEcommerceV14\OzEcommerceV14\Views\Product\CFilter.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>                                    
                                    <div class=""load-more-sec"">
                                        <a href=""javascript:void(0)"" class=""loadMore"">
                                            load
                                            more
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- section End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OzEcommerceV14.Models.ViewModels.ComboSetViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
