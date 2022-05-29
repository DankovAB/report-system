using ReportSystem.ReportConfiguration.EntityConfig;
using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.ReportConfiguration
{
    public abstract class ReportConfigurations<TConfOptions, TMemberOptions> : IReportConfigurations<TConfOptions, TMemberOptions>
        where TMemberOptions : IMemberOptions
        where TConfOptions : IConfigurationOptions
    {
        public virtual TConfOptions Options { get; }
        public virtual MemberConfigurationDictionary<TMemberOptions> MemberConfigurations { get; }

        protected ReportConfigurations(TConfOptions options, MemberConfigurationDictionary<TMemberOptions> memberConfigurations)
        {
            Options = options;
            MemberConfigurations = memberConfigurations;
        }
    }
}
