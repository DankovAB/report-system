using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Excel.ExcelReportConfiguration.OneTable.MemberConfig;
using ReportSystem.ReportConfiguration;

namespace ReportSystem.Excel.ExcelReportConfiguration.OneTable.EntityConfig
{
    public interface IOneTableExcelReportConfiguration
        : IReportConfigurations<IExcelConfigurationOptions, OneTableExcelMemberOptions>
    {
    }
}
