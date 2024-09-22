using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPdfDemo.models
{
    public class ReportOptions
    {
        public string Orientation { get; set; } // "Portrait" or "Landscape"
        public string Language { get; set; } // "AR" or "EN"
        public PageHeaderViewModel PageHeader { get; set; } = new PageHeaderViewModel();
        public List<header> TableHeaders { get; set; }
        public List<List<DataViewModel>> TableData { get; set; } // Rows of data
    }
    public class header()
    {
        public string name { get; set; }
        public float? width { get; set; }
    } 
    public class DataViewModel()
    {
        public string name { get; set; }
        public string value { get; set; }
    }
     public class PageHeaderViewModel()
    {
        public string ministryName { get; set; }
        public string? ministryImg { get; set; }
        public string ReportTitle { get; set; }
        public string ReportSubTitle { get; set; }
        public string EmployeeName { get; set; }
    }

}
