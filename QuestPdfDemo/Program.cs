using QuestPdfDemo;
using QuestPdfDemo.Report;
using QuestPdfDemo.ReportService;


var categoryData = DataSource.GetCategory();
var productData = DataSource.GetProducts();

PdfPageHeader PageHeader = new()
{
    ImageName = "Al Rayan Ministry",
    Title = "Dynamic Report Title"
                    ,
    SubTitle = "bla bla bla ",
    ImagePath = "favicon.ico"
};


PdfPageHeader PageHeaderForCategory = new()
{
    ImageName = "Al Rayan Ministry",
    Title = "Product Category Report Title"
                    ,
    SubTitle = "bla bla bla ",
    ImagePath = "favicon.ico"
};


var categoryReport = new ReportGeneratorOptions<Category>.Builder()
                        .SetPageHeader(PageHeader)
                        .SetTableData(categoryData)
                        .Build();


var productReport = new ReportGeneratorOptions<Product>.Builder()
                        .SetPageHeader(PageHeaderForCategory)
                        .SetTableData(productData)
                        .Build();



PDFReportGeneration report = new();
var categoryReportPDF = report.GeneratePdf(categoryReport);

var productReportPDF = report.GeneratePdf(productReport);

report.MergeDocuments(productReportPDF, categoryReportPDF);




