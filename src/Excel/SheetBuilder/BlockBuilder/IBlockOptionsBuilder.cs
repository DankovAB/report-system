using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;
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
        IBlockOptionsBuilder Style(ExcelStyle style);
        IBlockOptionsBuilder Style(ExcelPredefineStyle predefineStyle);
        IBlockOptionsBuilder Style(string styleName);
        IBlockOptions Build();
    }
}
