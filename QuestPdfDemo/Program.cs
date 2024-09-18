using QuestPdfDemo.models;
using QuestPdfDemo.Report;

var options = new ReportOptions
{
    HeaderTitle = "Dynamic Report Title",
    Orientation = "Portrait", // or "Landscape"
    Language = "EN", // or "AR"
    TableHeaders = new List<string> { "Name", "Value","Price" },
    TableData = new List<List<string>>
    {
        new List<string> { "dddddddddssssdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddsssssssssssssdd", "10" ,"15511512 $"},
        new List<string> { "Item 2", "20" ,"15511512 $"},
        new List<string> { "Item 3", "30" ,"15511512 $"},
    }
};

var report = new ReportGeneration(options);
report.GeneratePdf();