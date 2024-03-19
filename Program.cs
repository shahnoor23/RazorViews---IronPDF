using Items_Report;
using Items_Report.Models;
using Razor.Templating.Core;

var builder = WebApplication.CreateBuilder(args);

License.LicenseKey = "License Key";

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSingleton<ItemsSummaryReportFactory>();

var app = builder.Build();




app.MapGet("report", async (ItemsSummaryReportFactory itemsSummaryReportFactory) =>
{
    Root itemsSummaryReport = itemsSummaryReportFactory.LoadDataFromJson();
    var html = await RazorTemplateEngine.RenderAsync("/Pages/Index.cshtml", itemsSummaryReport);
    var renderer = new ChromePdfRenderer();
    string currentDateTime = DateTime.Now.ToString("MM/dd/yyyy");
    renderer.RenderingOptions.SetCustomPaperSizeinMilimeters(210, 297);
    renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
    renderer.RenderingOptions.MarginRight = 10; //millimeters
    renderer.RenderingOptions.MarginLeft = 10; //millimeters

    renderer.RenderingOptions.HtmlHeader.HtmlFragment = $@"
    <div style='text-align: center; margin-top: 50px; font-family: ""Lucida Console"", Monaco, monospace; color: black; font-size: 16px;'>
        <div style='display: inline-block; float: left;'>Items Summary Report</div>
        <div style='display: inline-block; margin-left: 50px;'>{currentDateTime}</div>
        <div style='display: inline-block; float: right;'>Page {{page}} of {{total-pages}}</div>

        <hr style='margin-top: 10px; border: none; border-top: 1px solid black;'>

        
    </div>";
    using var pdfDocument = renderer.RenderHtmlAsPdf(html);
    return Results.File(pdfDocument.BinaryData, "application/pdf", $"report.pdf");
});

app.UseHttpsRedirection();

app.Run();


