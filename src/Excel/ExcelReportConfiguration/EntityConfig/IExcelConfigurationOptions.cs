﻿using System.Collections.Generic;
using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;
using ReportSystem.ReportConfiguration.EntityConfig;

namespace ReportSystem.Excel.ExcelReportConfiguration.EntityConfig
{
    public interface IExcelConfigurationOptions: IConfigurationOptions
    {
        ExcelStyle HeaderStyle { get; set; }
        string HeaderStyleName { get; set; }
        bool IsSetHeaderStyle { get; set; }

        ExcelStyle DefaultStyle { get; set; }
        string DefaultStyleName { get; set; }
        bool IsSetDefaultStyle { get; set; }

        bool HasAlternateBackgroundColor { get; set; }
        IReadOnlyList<KeyValuePair<string, Color>> AlternateBackgroundColors { get; set; }
    }
}
