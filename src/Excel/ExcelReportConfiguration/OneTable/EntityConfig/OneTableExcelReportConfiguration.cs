using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Excel.ExcelReportConfiguration.OneTable.MemberConfig;
using ReportSystem.ReportConfiguration;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Excel.ExcelReportConfiguration.OneTable.EntityConfig
{
    public class OneTableExcelReportConfiguration
        : ReportConfigurations<IExcelConfigurationOptions, OneTableExcelMemberOptions>
            , IOneTableExcelReportConfiguration
    {
        public OneTableExcelReportConfiguration(IExcelConfigurationOptions options, MemberConfigurationDictionary<OneTableExcelMemberOptions> memberConfigurations)
            : base(options, memberConfigurations)
        {
        }
    }
}
