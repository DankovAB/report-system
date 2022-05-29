using ReportSystem.ReportConfiguration;
using ReportSystem.ReportConfiguration.EntityConfig;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Csv.CsvReportConfiguration.EntityConfig
{
    public interface ICsvReportConfiguration : IReportConfigurations<IConfigurationOptions, MemberOptions>
    {
    }
}
