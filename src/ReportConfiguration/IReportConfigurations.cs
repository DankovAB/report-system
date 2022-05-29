using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.ReportConfiguration
{
    public interface IReportConfigurations<out TConfOptions, TMemberOptions>
        : IReportConfigurations where TMemberOptions: IMemberOptions
    {
        TConfOptions Options { get; }
        MemberConfigurationDictionary<TMemberOptions> MemberConfigurations { get; }
    }

    public interface IReportConfigurations
    {

    }
}
