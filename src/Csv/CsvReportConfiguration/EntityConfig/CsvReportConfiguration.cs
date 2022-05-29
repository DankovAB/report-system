using ReportSystem.ReportConfiguration;
using ReportSystem.ReportConfiguration.EntityConfig;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Csv.CsvReportConfiguration.EntityConfig
{
    public class CsvReportConfiguration : ReportConfigurations<IConfigurationOptions, MemberOptions>, ICsvReportConfiguration
    {
        public CsvReportConfiguration(IConfigurationOptions options, MemberConfigurationDictionary<MemberOptions> memberConfigurations) : base(options, memberConfigurations)
        {
        }
    }
}
