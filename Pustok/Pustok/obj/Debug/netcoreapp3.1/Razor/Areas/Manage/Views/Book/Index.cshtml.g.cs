#pragma checksum "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc65c89a2a3b01758652ec678338bb553ffb4be7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Book_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Book/Index.cshtml")]
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
#line 1 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc65c89a2a3b01758652ec678338bb553ffb4be7", @"/Areas/Manage/Views/Book/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6e19ca324ad24e616aa94ac1bafb75507af549f", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Manage_Views_Book_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Book>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
  
    ViewData["Title"] = "Index";
  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-10 mx-auto"">
            <a class=""btn btn-primary"">Create</a>
        </div>
        <div class=""col-md-10 mx-auto"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">Cost Price</th>
                        <th scope=""col"">Sale Price </th>
                        <th scope=""col"">Genre Name</th>
                         <th scope=""col"">Author Name</th>
                        <th scope=""col"">Actions</th>
                        
                        
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 27 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                     foreach (var book in Model)
                    {
                       

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
#nullable restore
#line 31 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                                       Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                           Write(book.CostPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                           Write(book.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                           Write(book.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                             <td>");
#nullable restore
#line 35 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                            Write(book.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a class=\"btn btn-warning\">Edit</a>\r\n                                <a class=\"btn btn-danger\">Delete</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 41 "C:\Users\SAMSUNG\Desktop\ASP\Pustok\Pustok\Pustok\Areas\Manage\Views\Book\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Book>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
