﻿using ReportSystem.ReportConfiguration.MemberConfig;

namespace ReportSystem.Csv.CsvReportConfiguration.MemberConfig
{
    public class CsvMemberOptionsBuilder : MemberOptionsBuilder<CsvMemberOptionsBuilder, MemberOptions>, ICsvMemberOptionsBuilder
    {
        public CsvMemberOptionsBuilder(string memberName) : base(new MemberOptions(memberName))
        {
        }

        public CsvMemberOptionsBuilder(MemberOptions options) : base(options)
        {
        }
    }
}
