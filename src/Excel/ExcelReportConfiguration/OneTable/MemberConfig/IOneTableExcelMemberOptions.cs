using ReportSystem.Excel.ExcelReportConfiguration.MemberConfig;

namespace ReportSystem.Excel.ExcelReportConfiguration.OneTable.MemberConfig
{
    public interface IOneTableExcelMemberOptions:IExcelMemberOptions
    {
        double Width { get; set; }

        bool IsAutoFitColumn { get; set; }

        string Format { get; set; }
    }
}
