using System.Linq.Expressions;
using ReportSystem.Formaters;

namespace ReportSystem.ReportConfiguration.MemberConfig
{
    public interface IMemberOptions
    {
        string MemberName { get; }
        IFormatter Formatter { get; set; }
        Expression FormatterExpression { get; set; }
        string Header { get; set; }
        bool IsHeader { get; set; }
        bool Ignore { get; set; }
        int Order { get; set; }
    }
}
