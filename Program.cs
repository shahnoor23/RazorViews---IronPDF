using Items_Report;
using Items_Report.Models;
using Razor.Templating.Core;

var builder = WebApplication.CreateBuilder(args);

License.LicenseKey = "IRONSUITE.SHAHNOOR.KHALIDI.INLOOP.COM.AU.3882-495ED37D38-B6JU3BXKCQFGA3-6NNYZXN6DWPT-U5PO2UXQSNCP-YYH4O3J4I2J2-DBOS2KBLE5HD-E67YJVL7FZT5-C3FP3E-TW7LRWTV5KGMEA-DEPLOYMENT.TRIAL-N5VVV4.TRIAL.EXPIRES.05.APR.2024";

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


