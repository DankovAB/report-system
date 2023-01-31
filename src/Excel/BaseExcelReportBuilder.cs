using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;

namespace ReportSystem.Excel
{
    public abstract class BaseExcelReportBuilder<TSheetBuilder> : IBaseExcelReportBuilder<TSheetBuilder>
    {
        protected ExcelPackage Package;
        protected ExcelWorkbook Workbook => Package.Workbook;
        protected IExcelStyleApplier StyleApplier { get; set; }

        protected BaseExcelReportBuilder(IExcelStyleApplier styleApplier)
        {
            StyleApplier = styleApplier;
            Package = new ExcelPackage();
        }

        public abstract IBaseExcelReportBuilder<TSheetBuilder> Sheet(string sheetName,
            Func<TSheetBuilder, Task> action);
        public abstract IBaseExcelReportBuilder<TSheetBuilder> Sheet(string sheetName, Action<TSheetBuilder> action);

        public IBaseExcelReportBuilder<TSheetBuilder> PredefineStyles(IEnumerable<ExcelPredefineStyle> styles)
        {
            foreach (var style in styles)
            {
                var namedStyle = Workbook.Styles.CreateNamedStyle(style.Name);
                StyleApplier.ApplyStyle(style.Style, namedStyle.Style);
            }

            return this;
        }

        public byte[] Save()
        {
            return Package.GetAsByteArray();
        }

        public void SaveAs(FileInfo file)
        {
            Package.SaveAs(file);
        }

        public void SaveAs(Stream outputStream)
        {
            Package.SaveAs(outputStream);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Package.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
