#pragma checksum "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\Billing\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ae70ab2642b19883b70df8d190487f3bf9fc1f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Billing_Test), @"mvc.1.0.view", @"/Views/Billing/Test.cshtml")]
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
#line 1 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\_ViewImports.cshtml"
using WebAppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\_ViewImports.cshtml"
using WebAppMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\Billing\Test.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ae70ab2642b19883b70df8d190487f3bf9fc1f3", @"/Views/Billing/Test.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d71c890daac151288336527d688967613a7d246", @"/Views/_ViewImports.cshtml")]
    public class Views_Billing_Test : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<LedgerItemDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/stripe.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("payment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/stripeClient.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\Billing\Test.cshtml"
  
    Layout = "~/Views/Shared/_LayoutBilling.cshtml";
    var myModel = JsonSerializer.Serialize(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2ae70ab2642b19883b70df8d190487f3bf9fc1f36640", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
    <link rel=""stylesheet"" href=""https://unpkg.com/bootstrap-table@1.18.3/dist/bootstrap-table.min.css"" />
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.2/css/jquery.dataTables.min.css"" />

");
            }
            );
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row mt-3 mb-2"">
        <div class=""col-md-12 fw-bold fs-3"">Billing Portal</div>
    </div>
    <div class=""row"">
        <div class=""container mt-xxl-1 col-md-6"" style=""min-width: 30rem;"">
            <div class=""card text-white bg-secondary mb-3"">
                <div class=""container"">
                    <div class=""card-header mt-1"">
                        <h5>Enter test credit card data for processing and response. See options.</h5>
                    </div>
                    <div class=""card-body"">
                        <!-- Stripe payment widget -->
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae70ab2642b19883b70df8d190487f3bf9fc1f38923", async() => {
                WriteLiteral(@"
                            <div id=""card-element""><!--Stripe.js injects the Card Element--></div>
                            <button id=""submit"">
                                <div class=""spinner hidden"" id=""spinner""></div>
                                <span id=""button-text"">Pay now</span>
                            </button>
                            <p id=""card-error"" role=""alert""></p>
                            <p class=""result-message hidden"">
                                Payment succeeded, see the result in your
                                <a");
                BeginWriteAttribute("href", " href=\"", 1907, "\"", 1914, 0);
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">Stripe dashboard.</a> Refresh the page to pay again.\r\n                            </p>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""card-header"">Stripe Response</div>
                    <div class=""card-body"">
                        <h5 class=""card-title"">Primary card title</h5>
                        <p class=""card-text"">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""container mt-xxl-1 col-md-6"" style=""min-width: 30rem;"">
            <div class=""card text-white bg-secondary mb-3"">
                <div class=""card-header mt-1"">Testing Options</div>
                <div class=""card-body"">
                    <h5 class=""card-title"">Stripe Integration Testing</h5>
                    <p class=""card-text"">
                        Genuine card information cannot be used in test mode. Instead, use any of the following test card numbers,
                        a valid expiration date in the future, and any random");
            WriteLiteral(@" CVC number, to create a successful payment. Each basic test card’s billing country is set to U.S.
                    </p>
                    <div class=""row mb-1"">
                        <div class=""col-6 rounded-end"">Card Number</div>
                        <div class=""col-6 rounded-end"">Description</div>
                    </div>
                    <div id=""el"">
                        <div class=""row mb-1"">
                            <div class=""col-6 rounded-end"">
                                <input type=""text"" value=""4242 4242 0000 4242"" class=""myInput"" readonly />
                            </div>
                            <div class=""col-6 rounded-end"">Testing Options</div>
                        </div>
                        <div class=""row mb-1"">
                            <div class=""col-6 rounded-end"">
                                <input type=""text"" value=""4111 4242 0000 4242"" class=""myInput"" readonly />
                                <div class=""col-6 rounded-e");
            WriteLiteral(@"nd"">Testing Options</div>
                            </div>
                            <div class=""row mb-1"">
                                <div class=""col-6 rounded-end"" style=""background-color: black"">Testing Options</div>
                                <div class=""col-6 rounded-end"">Testing Options</div>
                            </div>
                            <div class=""row mb-1"">
                                <div class=""col-6 rounded-end"" style=""background-color: black"">Testing Options</div>
                                <div class=""col-6 rounded-end"">Testing Options</div>
                            </div>
                            <div class=""row mb-1"">
                                <div class=""col-6 rounded-end"" style=""background-color: black"">Testing Options</div>
                                <div class=""col-6 rounded-end"">Testing Options</div>
                            </div>
                        </div>
                    </div>
                        <");
            WriteLiteral(@"div class=""row mt-3"">
                            <h8 style=""font-style:italic"">reference: https://stripe.com/docs/testing</h8>
                        </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""container-fluid"">
        <div class=""row mt-3 mb-2"">
");
            WriteLiteral(@"            <table id=""dataTable"" class=""table table-responsive table-striped table-bordered table-hover"" data-s>
                <thead>
                    <tr>
                        <th data-field=""Posted"" data-formatter=""dateTimeStamp"">Posted</th>
                        <th data-field=""Description"">Billing Entry</th>
                        <th data-field=""Debit"" data-formatter=""currencyFormat"">Debit</th>
                        <th data-field=""Credit"" data-formatter=""currencyFormat"">Credit</th>
                        <th data-formatter=""getBalance"">Adjusted Balance</th>
                        <th data-field=""Remarks"">Remarks</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae70ab2642b19883b70df8d190487f3bf9fc1f315684", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae70ab2642b19883b70df8d190487f3bf9fc1f316788", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <!-- Bootstrap core JS-->\r\n        <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js\"></script>\r\n        <script src=\"https://cdn.startbootstrap.com/sb-forms-latest.js\"></script>\r\n\r\n");
                WriteLiteral(@"        <script src=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js""></script>
        <script src=""https://unpkg.com/bootstrap-table@1.18.3/dist/bootstrap-table.min.js""></script>
        <script src=""https://cdn.datatables.net/1.10.2/js/jquery.dataTables.min.js""></script>
        <script>

        var currencyFormatter = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
        });

        var format = function (data) {
            return currencyFormatter.format(data);
        }

        var currencyFormat = function (column, row, index) {
            return format(column);
        }

        var runningTotal = 0;
        //goes through every preceding row
        var getBalance = function (column, row, index) {
            runningTotal += row.Debit;
            runningTotal += row.Credit;
            return format(runningTotal);
        }

        var dateTimeStamp = function (dateInFirstColumn) {
            va");
                WriteLiteral(@"r date = new Date(dateInFirstColumn);
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var ampm = hours >= 12 ? 'PM' : 'AM';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;
            return (date.getMonth() + 1) + ""/"" + date.getDate() + ""/"" + date.getFullYear() + ""  "" + strTime;
        }


        //get model from backend to front end
        var s = `");
#nullable restore
#line 169 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\Billing\Test.cshtml"
            Write(Html.Raw(myModel));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"`;
        var jsonData = JSON.parse(s);

        $(document).ready(function () {
            var $table = $('#dataTable')
            $table.bootstrapTable({
                data: jsonData
            });
            $table.dataTable();
        });



        </script>




");
                WriteLiteral(@"        <script type=""text/javascript"">
            var purchase = {
                items: [{ id: ""xl-tshirt"", amount: 2 }]
            };
        </script>
        <script src=""https://js.stripe.com/v3/""></script>
        <script src=""https://polyfill.io/v3/polyfill.min.js?version=3.52.1&features=fetch""></script>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ae70ab2642b19883b70df8d190487f3bf9fc1f320751", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 195 "C:\Users\deidr\repos\microservices\MicroServicesSolution\WebAppMVC\Views\Billing\Test.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("defer", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"


        <script>
            $("".myInput"").click(function () {
                var text = $(this).val();
                $('input[name=""cardnumber""]').val(text);
                //navigator.clipboard.writeText(text);

                //alert(""Copied the text: "" + text);
            });
        </script>



    ");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<LedgerItemDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
