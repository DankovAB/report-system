﻿using ReportSystem.Excel.ExcelReportConfiguration.MemberConfig;

namespace ReportSystem.Excel.ExcelReportConfiguration.OneTable.MemberConfig
{
    public class OneTableExcelMemberOptions: ExcelMemberOptions, IOneTableExcelMemberOptions
    {
        public double Width { get; set; }
        public bool IsAutoFitColumn { get; set; }
        public string Format { get; set; }

        public OneTableExcelMemberOptions()
        {
        }

        public OneTableExcelMemberOptions(string memberName) : base(memberName)
        {
        }
    }
}
