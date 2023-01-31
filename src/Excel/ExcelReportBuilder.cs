﻿using System;
using System.Threading.Tasks;
using ReportSystem.Excel.SheetBuilder;

namespace ReportSystem.Excel
{
    public class ExcelReportBuilder: BaseExcelReportBuilder<ISheetBuilder>
        , IExcelReportBuilder
    {
        public ExcelReportBuilder(IExcelStyleApplier styleApplier) : base(styleApplier)
        {
        }

        public override IBaseExcelReportBuilder<ISheetBuilder> Sheet(string sheetName,
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

        public override IBaseExcelReportBuilder<ISheetBuilder> Sheet(string sheetName, Action<ISheetBuilder> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new SheetBuilder.SheetBuilder(StyleApplier, worksheet);
            action(sheetBuilder);

            return this;
        }

        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
