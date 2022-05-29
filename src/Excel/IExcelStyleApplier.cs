using OfficeOpenXml;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;

namespace ReportSystem.Excel
{
    public interface IExcelStyleApplier
    {
        void ApplyStyle(string styleName, ExcelStyle style, ExcelRange range);

        void ApplyStyle(ExcelStyle sourceStyle, OfficeOpenXml.Style.ExcelStyle destinationStyle);
    }
}
