using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPdfDemo.ReportService;
using QuestPdfDemo.Styles;

namespace QuestPdfDemo.Report;

public class PDFReportGeneration
{
    public void MergeDocuments(params IDocument[] documents)
    {

        Document
                .Merge(documents)
                .UseContinuousPageNumbers()
                .ShowInPreviewer();
    }

    public Document GeneratePdf<T>(ReportGeneratorOptions<T> tables)
    {

        return Document.Create(container =>
        {
            container
            .Page(page =>
            {
                // Set orientation
                page.Size(tables.Orientation == PdfOrientation.Landscape ? PageSizes.A4.Landscape() : PageSizes.A4.Portrait());

                page.Margin(50);

                page.Header()
                .ShowOnce()
                    .Element(c => ComposeHeader(c, tables.PageHeader));

                page.Content()
                    .Element(c => ComposeBody(c, tables.TableHeaders, tables.TableData));

                page.Footer()
                    .Element(ComposeFooter);
            });

        });

    }
   

    private void ComposeHeader(IContainer container, PdfPageHeader header)
    {
        container.Row(row =>
        {

            row.ConstantItem(150)
            .PaddingTop(20)
            .Height(90)
           .Text(header.Title)
           .FontSize(26).FontColor(Colors.Orange.Accent4).SemiBold();

            row.RelativeItem().PaddingTop(20).Height(90).Column(column =>

            {
                column.Item().Text(header.SubTitle).Style(Typography.Title).AlignCenter();
            });
            row.RelativeItem().Height(80).Column(column =>
            {

                column.Item().AlignCenter().Height(40).Width(40).Image(header.ImagePath ?? "favicon.ico");
                column.Item().AlignCenter().Text(header.ImageName)
                 .FontColor(Colors.Orange.Accent4).SemiBold();
                column.Item().AlignCenter().Text(Placeholders.Label());
            });


        });
    }
    private void ComposeBody<T>(IContainer container, List<TableHeader> headers, List<T> data)
    {
        container.PaddingBottom(1).Extend().Table(table =>
        {

            table.ColumnsDefinition(columns =>
            {
                foreach (var header in headers)
                {
                    columns.RelativeColumn(header.Width);
                }
            });

            table.Header(headerRow =>
            {
                foreach (var header in headers)
                {
                    headerRow.Cell().Element(headerBlock).Text(header.Name);
                }
            });
            foreach (var row in data)
            {
                foreach (var header in headers)
                {
                    //trim()
                    var property = typeof(T).GetProperty(header.Name.Replace(" ", ""));

                    var value = property != null ? property.GetValue(row)?.ToString() : string.Empty;
                    table.Cell().Element(Block).Text(value);
                }
            }
        });
    }
    private IContainer Block(IContainer container)
    {
        return container
            .Border(1)
            .Background(Colors.Grey.Lighten3)
            .PaddingVertical(5)
            .ShowEntire()
            .AlignCenter()
            .AlignMiddle()
            .AlignCenter();
    }
    private static IContainer headerBlock(IContainer container)
    {
        return container
            .Border(1)
            .Background(Colors.Grey.Lighten3)
            .PaddingBottom(1)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle();
    }
    private void ComposeFooter(IContainer container)
    {
        container.AlignCenter().Text(text =>
        {
            text.DefaultTextStyle(x => x.FontSize(16));
            text.Span("Page Number ");
            text.CurrentPageNumber();
            text.Span(" of ").FontColor(Colors.Orange.Accent4).Underline();
            text.TotalPages();
        });
    }
}
