using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPdfDemo.models
{
    public class ReportOptions
    {
        public string HeaderTitle { get; set; }
        public string Orientation { get; set; } // "Portrait" or "Landscape"
        public string Language { get; set; } // "AR" or "EN"
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
        public string name { get; set; }
        public string value { get; set; }
    }

}
