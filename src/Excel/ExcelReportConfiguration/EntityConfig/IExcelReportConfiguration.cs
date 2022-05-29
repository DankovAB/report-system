using ReportSystem.Excel.ExcelReportConfiguration.MemberConfig;
using ReportSystem.ReportConfiguration;

namespace ReportSystem.Excel.ExcelReportConfiguration.EntityConfig
{
    public interface IExcelReportConfiguration
        : IReportConfigurations<IExcelConfigurationOptions, ExcelMemberOptions>
    {
    }
}
