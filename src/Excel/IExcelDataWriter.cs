using System.Collections.Generic;
using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Excel.ExcelReportConfiguration.MemberConfig;

namespace ReportSystem.Excel
{
    public interface IExcelDataWriter
    {
        void WriteValue<T>(T value, IExcelMemberOptions options, DisplayType display);
        void Write<TEntity>(IEnumerable<TEntity> source, IExcelReportConfiguration configuration) where TEntity : class;
    }
}
