﻿using System;
using System.Threading.Tasks;
using ReportSystem.Excel.SheetBuilder.OneTable;

namespace ReportSystem.Excel
{
    public class OneTableExcelReportBuilder : BaseExcelReportBuilder<IOneTableSheetBuilder>, IOneTableExcelReportBuilder
    {
        public OneTableExcelReportBuilder(IExcelStyleApplier styleApplier) : base(styleApplier)
        {
        }

        public override IBaseExcelReportBuilder<IOneTableSheetBuilder> Sheet(string sheetName, Func<IOneTableSheetBuilder, Task> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new OneTableSheetBuilder(StyleApplier, worksheet);
            Task.Run(async () =>
            {
                await action(sheetBuilder);
            }).Wait();

            return this;
        }

        public override IBaseExcelReportBuilder<IOneTableSheetBuilder> Sheet(string sheetName,
            Action<IOneTableSheetBuilder> action)
        {
            var worksheet = Workbook.Worksheets.Add(sheetName);

            var sheetBuilder = new OneTableSheetBuilder(StyleApplier, worksheet);
            action(sheetBuilder);

            return this;
        }

        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
