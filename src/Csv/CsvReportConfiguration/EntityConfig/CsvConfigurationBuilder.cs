using ReportSystem.Csv.CsvReportConfiguration.MemberConfig;
using ReportSystem.ReportConfiguration.EntityConfig;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Csv.CsvReportConfiguration.EntityConfig
{
    public class CsvConfigurationBuilder<TEntity>
        : ConfigurationBuilder<TEntity, CsvMemberOptionsBuilder, CsvConfigurationBuilder<TEntity>, CsvReportConfiguration, MemberOptions>
        where TEntity : class
    {
        public CsvConfigurationBuilder() : base(new ConfigurationOptions())
        {
        }

        public CsvConfigurationBuilder(IConfigurationOptions options) : base(options)
        {
        }

        public override CsvReportConfiguration BuildConfiguration()
        {
            return BuildConfiguration<IConfigurationOptions>();
        }
    }
}
