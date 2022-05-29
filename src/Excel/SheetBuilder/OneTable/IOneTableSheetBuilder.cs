using System.Collections.Generic;
using ReportSystem.Excel.ExcelReportConfiguration.OneTable.EntityConfig;

namespace ReportSystem.Excel.SheetBuilder.OneTable
{
    public interface IOneTableSheetBuilder : IBaseSheetBuilder<OneTableSheetBuilder>
    {
        void DataContent<T>(IEnumerable<T> data, IOneTableExcelReportConfiguration configuration)
            where T : class;
        void DataContent<T>(IEnumerable<T> data)
            where T : class;
    }
}
