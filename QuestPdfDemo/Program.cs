using QuestPdfDemo.models;
using QuestPdfDemo.Report;
using System.ComponentModel.DataAnnotations;

var options = new ReportOptions
{
    HeaderTitle = "Dynamic Report Title",
    Orientation = "Portrait", // or "Landscape"
    Language = "EN", // or "AR"
    TableHeaders = headers(),
    TableData = Data()
};
static List<header> headers()
{

    var listOf = new List<header>() {
    new header { name="Product Name" ,width=3},
    new header { name="Price"  ,width=1},
    new header { name = "Quantity", width = 2},
    new header { name="Value"  ,width=1},
    new header { name = "test" },
};
return listOf;
}
static List<List<DataViewModel>> Data()
{
    var listOf = new List<List<DataViewModel>>()
    {
        new List<DataViewModel>
        {
            new DataViewModel { name = "Product Name", value = "hhhhheee" },
            new DataViewModel { name = "Price", value = "20" },
            new DataViewModel { name = "Quantity", value = "30" },
            new DataViewModel { name = "Value", value = "100" },
            new DataViewModel { name = "test", value = "ddddf" }
        }
    };

    return listOf;
}


var report = new ReportGeneration(options);
report.GeneratePdf();
//static List<List<string>> Data()
//{

//    var listOf = new List<List<string>>
//    {
//        new List<string> { "dddddddddssssdddddddddddddddddddddddddddddddddddddddddddddddddddd" +
//        "dddddddddddddddsssssssssssssdd", "10" ,"15511512 $","50","testtststststs"},
//        new List<string> { "Item 2", "20" ,"15511512 $","22552222","testtststststs"},
//        new List<string> { "Item 3", "30" ,"15511512 $","22552222","testtststststs"},
//    };
//return listOf;
//}