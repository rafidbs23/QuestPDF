using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuestPdfDemo.models
{
    public class ReportOptions<T>
    {
        public string Orientation { get; set; } // "Portrait" or "Landscape"
        public string Language { get; set; } // "AR" or "EN"
        public PageHeaderViewModel PageHeader { get; set; } = new PageHeaderViewModel();
        public List<Header> TableHeaders { get; set; } 
        public List<T> TableData { get; set; } 

        public ReportOptions(string orientation , string language,
            PageHeaderViewModel pageHeader,
            List<Header> headers, List<T> data)
        {
            Orientation = orientation;
            Language = language;
            PageHeader = pageHeader;
            TableHeaders = headers;
            TableData = data;
        } // Rows of data
    }
    public class Header
    {
        public string Name { get; set; } // Header name
        public float Width { get; set; } // Column width

        public Header(string name, float width)
        {
            Name = name;
            Width = width;
        }
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
