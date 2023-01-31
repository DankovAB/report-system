using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;

namespace ReportSystem.Excel
{
    public interface IBaseExcelReportBuilder<out TSheetBuilder> : IDisposable
    {
        IBaseExcelReportBuilder<TSheetBuilder> Sheet(string sheetName, Func<TSheetBuilder, Task> action);
        IBaseExcelReportBuilder<TSheetBuilder> Sheet(string sheetName, Action<TSheetBuilder> action);
        IBaseExcelReportBuilder<TSheetBuilder> PredefineStyles(IEnumerable<ExcelPredefineStyle> styles);
        byte[] Save();
        void SaveAs(FileInfo file);
        void SaveAs(Stream outputStream);
    }
}
