#pragma checksum "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2ef52662ca6f8eda45f0b785f5deb9b9a73c335"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produits_Index), @"mvc.1.0.view", @"/Views/Produits/Index.cshtml")]
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
#line 1 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\_ViewImports.cshtml"
using ecommerce_Website_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\_ViewImports.cshtml"
using ecommerce_Website_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2ef52662ca6f8eda45f0b785f5deb9b9a73c335", @"/Views/Produits/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66bb4d1b803ffef9af6e498d09383029b229e73f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produits_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ecommerce_Website_MVC.Models.Produit>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Achats", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Produits", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
  
    ViewData["Title"] = "Produits";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section id=\"product1\" class=\"section-p1\">\r\n    <h2>Products</h2>\r\n    <p>New Collection</p>\r\n    <div class=\"pro-container\">\r\n");
#nullable restore
#line 10 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"pro\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 331, "\"", 351, 1);
#nullable restore
#line 13 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
WriteAttributeValue("", 337, item.imageUrl, 337, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 352, "\"", 374, 1);
#nullable restore
#line 13 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
WriteAttributeValue("", 358, item.nomProduit, 358, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <div class=\"des\">\r\n                    <span>");
#nullable restore
#line 15 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
                     Write(item.nomProduit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <h5>");
#nullable restore
#line 16 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
                   Write(item.description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    <div class=""star"">
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                    </div>
                    <h4>");
#nullable restore
#line 24 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
                   Write(item.prixProduit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2ef52662ca6f8eda45f0b785f5deb9b9a73c3358234", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 1061, "\"", 1077, 1);
#nullable restore
#line 27 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
WriteAttributeValue("", 1069, item.id, 1069, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"idCategorie\"");
                BeginWriteAttribute("value", " value=\"", 1142, "\"", 1167, 1);
#nullable restore
#line 28 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
WriteAttributeValue("", 1150, item.categorieId, 1150, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                    <input type=""hidden"" name=""page"" value=""0"" />
                    <div class=""input-group"">
                        <label for=""quantity"">Quantité :</label>
                        <input type=""number"" name=""quantitySelected"" id=""quantitySelected"" value=""1"" min=""1""");
                BeginWriteAttribute("max", " max=\"", 1461, "\"", 1481, 1);
#nullable restore
#line 32 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
WriteAttributeValue("", 1467, item.qteStock, 1467, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"input-quantity\" />\r\n                    </div>\r\n                    <button type=\"submit\" class=\"cart\"><i class=\"fas fa-shopping-cart\"></i> </button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"button-group\">\r\n                    <button type=\"button\" class=\"btn btn-details\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2ef52662ca6f8eda45f0b785f5deb9b9a73c33512080", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-info-circle\"></i> Détails\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
                                                                                   WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </button>\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 46 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 50 "D:\ILISI\ILISI 2024-2025 3A\ASP.NET - B -\ecommerce_Website_MVC\ecommerce_Website_MVC\Views\Produits\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ecommerce_Website_MVC.Models.Produit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
