using ReportSystem.Excel.ExcelReportConfiguration.MemberConfig;
using ReportSystem.ReportConfiguration;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Excel.ExcelReportConfiguration.EntityConfig
{
    public class ExcelReportConfiguration
        : ReportConfigurations<IExcelConfigurationOptions, ExcelMemberOptions>
            , IExcelReportConfiguration
    {
        public ExcelReportConfiguration(IExcelConfigurationOptions options, MemberConfigurationDictionary<ExcelMemberOptions> memberConfigurations)
            : base(options, memberConfigurations)
        {
        }
    }
}
