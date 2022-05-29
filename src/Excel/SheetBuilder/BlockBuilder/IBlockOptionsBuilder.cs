using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles.Enums;

namespace ReportSystem.Excel.SheetBuilder.BlockBuilder
{
    public interface IBlockOptionsBuilder
    {
        IBlockOptionsBuilder ColSpan(int colSpan);
        IBlockOptionsBuilder RowSpan(int rowSpan);
        IBlockOptionsBuilder Background(Color color);
        IBlockOptionsBuilder HAlign(ExcelHorizontalAlignment alignment);
        IBlockOptionsBuilder VAlign(ExcelVerticalAlignment alignment);
        IBlockOptionsBuilder Style(ExcelReportConfiguration.Styles.ExcelStyle style);
        IBlockOptionsBuilder Style(string styleName);
        IBlockOptions Build();
    }
}
