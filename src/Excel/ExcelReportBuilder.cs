using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;
using ReportSystem.Excel.SheetBuilder;
using ReportSystem.Excel.SheetBuilder.OneTable;

namespace ReportSystem.Excel
{
    public class ExcelReportBuilder: BaseExcelReportBuilder<ExcelReportBuilder, ISheetBuilder>, IExcelReportBuilder
    {
        public ExcelReportBuilder(IExcelStyleApplier styleApplier) : base(styleApplier)
        {
        }

        public override ExcelReportBuilder Sheet(string sheetName,
            Func<ISheetBuilder, Task> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new SheetBuilder.SheetBuilder(StyleApplier, worksheet);
            Task.Run(async () =>
            {
                await action(sheetBuilder);

            }).Wait();

            return this;
        }

        public override ExcelReportBuilder Sheet(string sheetName, Action<ISheetBuilder> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new SheetBuilder.SheetBuilder(StyleApplier, worksheet);
            action(sheetBuilder);

            return this;
        }

        public ExcelReportBuilder Sheet(string sheetName, Func<IOneTableSheetBuilder, Task> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new OneTableSheetBuilder(StyleApplier, worksheet);
            Task.Run(async () =>
            {
                await action(sheetBuilder);
            }).Wait();

            return this;
        }

        public ExcelReportBuilder Sheet(string sheetName, Action<IOneTableSheetBuilder> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new OneTableSheetBuilder(StyleApplier, worksheet);
            action(sheetBuilder);

            return this;
        }

        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
