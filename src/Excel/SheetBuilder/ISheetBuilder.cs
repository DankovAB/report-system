using System;
using System.Collections.Generic;
using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Excel.SheetBuilder.BlockBuilder;

namespace ReportSystem.Excel.SheetBuilder
{
    public interface ISheetBuilder: IBaseSheetBuilder<SheetBuilder>
    {
        ISheetBuilder Block(Action<IBlockBuilder> action);
        ISheetBuilder Column(int columnNumber, Action<IColumnBuilder> action);
        ISheetBuilder AutoFitColumns(int fromColumnsNumber, int toColumnsNumber);
        ISheetBuilder DataContent<T>(IEnumerable<T> data, IExcelReportConfiguration configuration)
            where T : class;

        ISheetBuilder DataContent<T>(IEnumerable<T> data)
            where T : class;
    }
}
