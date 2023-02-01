using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;

namespace ReportSystem.Excel
{
    public interface IBaseExcelReportBuilder<TReport,out TSheetBuilder>
        : IDisposable
        where TReport : IBaseExcelReportBuilder<TReport, TSheetBuilder>
    {
        TReport Sheet(string sheetName, Func<TSheetBuilder, Task> action);
        TReport Sheet(string sheetName, Action<TSheetBuilder> action);
        IBaseExcelReportBuilder<TReport, TSheetBuilder> PredefineStyles(IEnumerable<ExcelPredefineStyle> styles);
        byte[] Save();
        void SaveAs(FileInfo file);
        void SaveAs(Stream outputStream);
    }
}
