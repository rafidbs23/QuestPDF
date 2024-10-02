using System.Reflection.PortableExecutable;

namespace QuestPdfDemo.ReportService;
public static class PdfOrientation
{
    public const string Portrait = "Portrait";
    public const string Landscape = "Landscape";
}
public class ReportGeneratorOptions<T>
{
    public string Orientation { get; private set; } 
    public PdfPageHeader PageHeader { get; private set; }
    public List<TableHeader> TableHeaders { get; private set; }
    public List<T> TableData { get; private set; }
    public bool IsPageHeader => PageHeader != null;
    private ReportGeneratorOptions() { }

    public class Builder
    {
        private readonly ReportGeneratorOptions<T> _reportOptions;

        public Builder()
        {
            _reportOptions = new ReportGeneratorOptions<T>
            {
                PageHeader = new PdfPageHeader(),
                Orientation = PdfOrientation.Portrait
            };
        }
        public Builder SetOrientation(string orientation)
        {
            _reportOptions.Orientation = orientation;
            return this;
        }

        public Builder SetPageHeader(PdfPageHeader pageHeader)
        {
            _reportOptions.PageHeader = pageHeader;
            return this;
        }

        public Builder SetTableHeaders(List<TableHeader> headers)
        {
            _reportOptions.TableHeaders = headers;
            return this;
        }

        public Builder SetTableData(List<T> data)
        {
            _reportOptions.TableData = data;
            return this;
        }

        public ReportGeneratorOptions<T> Build()
        {
            if (_reportOptions.TableHeaders is null)
            {
                GenerateTableHeadersFromData();
            }
            return _reportOptions;
        }
        private void GenerateTableHeadersFromData()
        {
            if (_reportOptions.TableData is null || _reportOptions.TableData.Count == 0)
            {
                return;
            }

            var firstItem = _reportOptions.TableData.First();
            var properties = typeof(T).GetProperties();

            List<TableHeader> headers = properties.Select(prop => new TableHeader(prop.Name, 1)).ToList();

            _reportOptions.TableHeaders = headers;
        }

    }
}

public class PdfPageHeader
{
    public string? ImagePath { get; set; }
    public string? ImageName { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
}
public record TableHeader(string Name, float Width);
