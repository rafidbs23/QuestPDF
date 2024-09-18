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
        public List<string> TableHeaders { get; set; }
        public List<List<string>> TableData { get; set; } // Rows of data
    }
}
