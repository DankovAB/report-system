using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles.Enums;

namespace ReportSystem.Excel.SheetBuilder.BlockBuilder
{
    public interface IBlockOptions
    {
        object Value { get; }
        int ColSpan { get; set; }
        int RowSpan { get; set; }
        Color? BackgroundColor { get; set; }
        ExcelHorizontalAlignment? HAlign { get; set; }
        ExcelVerticalAlignment? VAlign { get; set; }
        ExcelReportConfiguration.Styles.ExcelStyle Style { get; set; }
        DisplayType Display { get; set; }
        string StyleName { get; set; }
    }
}
