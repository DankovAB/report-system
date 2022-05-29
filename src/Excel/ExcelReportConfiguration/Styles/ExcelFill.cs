using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles.Enums;

namespace ReportSystem.Excel.ExcelReportConfiguration.Styles
{
    public class ExcelFill
    {
        public ExcelFillStyle? PatternType { get; set; }
        public Color? PatternColor { get; set; }
        public Color? BackgroundColor { get; set; }
    }
}
