using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using ReportSystem.Excel;
using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Excel.ExcelReportConfiguration.OneTable.EntityConfig;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;
using ReportSystem.Excel.ExcelReportConfiguration.Styles.Enums;
using Xunit;

namespace ReportSystem.Tests.ExcelTests
{
    public class ExcelGenerateReportShould
    {
        [Fact]
        public void GenerateReport()
        {
            var extendedData = Generate(1_000_000);

            var confBuilder = CreateExcelConfigurationBuilder();

            var reportBuilder = new OneTableExcelReportBuilder(new ExcelStyleApplier())
                .PredefineStyles(DemoReportStyles.AllPredefineStyles);

            var watch = Stopwatch.StartNew();

            watch.Start();
            reportBuilder.Sheet("test", sheetBuilder =>
            {
                sheetBuilder.DataContent(extendedData, confBuilder.BuildConfiguration());
            });
            watch.Stop();
            Debug.WriteLine("write data took: " + watch.Elapsed.TotalSeconds);
        }

        private IEnumerable<ScenarioCampaignExtendedResultItem> Generate(int count)
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                yield return new ScenarioCampaignExtendedResultItem()
                {
                    AgencyName = "AgencyName",
                    AutomatedBooked = random.Next(1, 2) == 1,
                    CampaignExternalId = random.Next(1, 10000).ToString(),
                    ClashCode = random.Next(1, 100).ToString(),
                    CreationDate = DateTime.Now,
                    DaypartName = "M",
                    ISRCancelledRatings = random.NextDouble(),
                    ISRCancelledSpots = random.NextDouble(),
                    MediaSalesGroup = "Test",
                    NominalValue = random.Next(0, 100),
                    OptimiserBookedSpots = random.Next(0, 100),
                    OptimiserRatings = random.Next(0, 100),
                    PreRunRatings = random.Next(0, 100),
                    ProductAssignee = "Test",
                    RSCancelledRatings = random.Next(0, 100),
                    RSCancelledSpots = random.Next(0, 100),
                    ReportingCategory = "Report Category",
                    SalesAreaName = "Sales Area",
                    SpotLength = random.Next(0, 100),
                    StopBooking = random.Next(1, 2) == 1,
                    StrikeWeightEndDate = DateTime.Now,
                    StrikeWeightStartDate = DateTime.Now,
                    TargetRatings = random.Next(0, 100),
                    ZeroRatedSpots = random.Next(0, 100)
                };
            }
        }

        private class ScenarioCampaignExtendedResultItem
        {
            /// <summary>
            /// CampaignExternalId
            /// </summary>
            public string CampaignExternalId { get; set; }

            /// <summary>
            /// SalesAreaName
            /// </summary>
            public string SalesAreaName { get; set; }

            /// <summary>
            /// SpotLength
            /// </summary>
            public int SpotLength { get; set; }

            /// <summary>
            /// StrikeWeightStartDate
            /// </summary>
            public DateTime StrikeWeightStartDate { get; set; }

            /// <summary>
            /// StrikeWeightEndDate
            /// </summary>
            public DateTime StrikeWeightEndDate { get; set; }

            /// <summary>
            /// DaypartName
            /// </summary>
            public string DaypartName { get; set; }

            /// <summary>
            /// TargetRatings
            /// </summary>
            public double TargetRatings { get; set; }

            /// <summary>
            /// PreRunRatings
            /// </summary>
            public double PreRunRatings { get; set; }

            /// <summary>
            /// ISRCancelledRatings
            /// </summary>
            public double ISRCancelledRatings { get; set; }

            /// <summary>
            /// ISRCancelledSpots
            /// </summary>
            public double ISRCancelledSpots { get; set; }

            /// <summary>
            /// RSCancelledRatings
            /// </summary>
            public double RSCancelledRatings { get; set; }

            /// <summary>
            /// RSCancelledSpots
            /// </summary>
            public double RSCancelledSpots { get; set; }

            /// <summary>
            /// OptimiserRatings
            /// </summary>
            public double OptimiserRatings { get; set; }

            /// <summary>
            /// OptimiserBookedSpots
            /// </summary>
            public double OptimiserBookedSpots { get; set; }

            /// <summary>
            /// ZeroRatedSpots
            /// </summary>
            public double ZeroRatedSpots { get; set; }

            /// <summary>
            /// NominalValue
            /// </summary>
            public double NominalValue { get; set; }

            public string MediaSalesGroup { get; set; }

            public string ProductAssignee { get; set; }

            public bool StopBooking { get; set; }

            public DateTime? CreationDate { get; set; }

            public bool? AutomatedBooked { get; set; }

            public string TopTail { get; set; } = "Multipart";

            public string ReportingCategory { get; set; }

            public string ClashCode { get; set; }

            public string AgencyName { get; set; }
        }

        private OneTableExcelConfigurationBuilder<ScenarioCampaignExtendedResultItem> CreateExcelConfigurationBuilder()
        {
            var confBuilder = new OneTableExcelConfigurationBuilder<ScenarioCampaignExtendedResultItem>();

            confBuilder.DefaultStyle(DemoReportStyles.DataCellStyle.Name)
                .HeaderStyle(DemoReportStyles.HeaderStyle.Name)
                .AlternateBackgroundColors(DemoReportStyles.AlternateBackgroundColors);

            confBuilder
                .OrderMembersAsDescribed()
                .IgnoreNotDescribed()
                .ForMember(m => m.ClashCode, o => o.Width(25))
                .ForMember(m => m.AgencyName, o => o.Width(25))
                .ForMember(m => m.StrikeWeightStartDate, o => o.Formatter(ReportFormatter.ConvertToShortDate).Width(25))
                .ForMember(m => m.StrikeWeightEndDate, o => o.Formatter(ReportFormatter.ConvertToShortDate).Width(25))
                .ForMember(m => m.DaypartName, o => o.Width(25))
                .ForMember(m => m.TargetRatings, o => o.Width(25))
                .ForMember(m => m.PreRunRatings, o => o.Width(25).Header("PreRun Ratings"))
                .ForMember(m => m.ISRCancelledRatings, o => o.Width(30))
                .ForMember(m => m.ISRCancelledSpots, o => o.Width(25))
                .ForMember(m => m.RSCancelledRatings, o => o.Width(25))
                .ForMember(m => m.RSCancelledSpots, o => o.Width(25))
                .ForMember(m => m.OptimiserRatings, o => o.Width(25))
                .ForMember(m => m.OptimiserBookedSpots, o => o.Width(25))
                .ForMember(m => m.ReportingCategory, o => o.Width(30))
                .ForMember(m => m.ProductAssignee, o => o.Width(30))
                .ForMember(m => m.CreationDate, o => o.Formatter(ReportFormatter.ConvertToShortDate).Width(25))
                .ForMember(m => m.AutomatedBooked, o => o.Width(30))
                .ForMember(m => m.TopTail, o => o.Width(30).Header("Top/Tail"))
                .ForMember(m => m.StopBooking, o => o.Width(30))
                .ForMember(m => m.MediaSalesGroup, o => o.Width(30));

            confBuilder
                .ForMember(m => m.ZeroRatedSpots, o => o.Width(25))
                .ForMember(m => m.NominalValue, o => o.Width(30));

            return confBuilder;
        }

        public static class DemoReportStyles
        {
            public static ExcelPredefineStyle DataCellStyle =>
                new ExcelPredefineStyle("Data Cell", new ExcelStyle()
                {
                    Border = new ExcelBorder(new ExcelBorderItem
                    {
                        Style = ExcelBorderStyle.Hair
                    }),
                    Font = new ExcelFont
                    {
                        FontColor = Color.Black,
                        Font = new Font("Calibri", 11, FontStyle.Regular)
                    },
                    Fill = new ExcelFill
                    {
                        PatternType = ExcelFillStyle.Solid,
                        BackgroundColor = Color.White
                    }
                });

            public static ExcelPredefineStyle EmptyCellStyle =>
               new ExcelPredefineStyle("Empty Cell", new ExcelStyle()
               {
                   Border = new ExcelBorder(new ExcelBorderItem
                   {
                       Style = ExcelBorderStyle.Hair
                   }),
                   Font = new ExcelFont
                   {
                       FontColor = Color.Black,
                       Font = new Font("Calibri", 11, FontStyle.Regular)
                   },
                   Fill = new ExcelFill
                   {
                       PatternType = ExcelFillStyle.LightDown,
                       PatternColor = Color.LightGray,
                       BackgroundColor = Color.White
                   }
               });

            public static ExcelPredefineStyle CourierNewFontCellStyle =>
               new ExcelPredefineStyle("Break Exclusions", new ExcelStyle()
               {
                   Border = new ExcelBorder(new ExcelBorderItem
                   {
                       Style = ExcelBorderStyle.Hair
                   }),
                   Font = new ExcelFont
                   {
                       FontColor = Color.Black,
                       Font = new Font("Courier New", 11, FontStyle.Regular)
                   },
                   Fill = new ExcelFill
                   {
                       PatternType = ExcelFillStyle.Solid,
                       BackgroundColor = Color.White
                   }
               });

            public static ExcelPredefineStyle HeaderStyle =>
                new ExcelPredefineStyle("Header 1", new ExcelStyle
                {
                    Border = new ExcelBorder(new ExcelBorderItem
                    {
                        Style = ExcelBorderStyle.Thin
                    }),
                    Font = new ExcelFont
                    {
                        FontColor = Color.White,
                        Font = new Font("Calibri", 11, FontStyle.Bold)
                    },
                    Fill = new ExcelFill
                    {
                        PatternType = ExcelFillStyle.Solid,
                        BackgroundColor = Color.FromArgb(31, 78, 120)
                    }
                });

            public static ExcelPredefineStyle LightHeaderStyle =>
               new ExcelPredefineStyle("Header 2", new ExcelStyle
               {
                   Border = new ExcelBorder(new ExcelBorderItem
                   {
                       Style = ExcelBorderStyle.Thin
                   }),
                   Font = new ExcelFont
                   {
                       FontColor = Color.White,
                       Font = new Font("Calibri", 11, FontStyle.Bold)
                   },
                   Fill = new ExcelFill
                   {
                       PatternType = ExcelFillStyle.Solid,
                       BackgroundColor = Color.FromArgb(47, 117, 181)
                   }
               });

            public static IEnumerable<ExcelPredefineStyle> AllPredefineStyles
            {
                get { return new[] { HeaderStyle, LightHeaderStyle, DataCellStyle, CourierNewFontCellStyle, EmptyCellStyle }; }
            }

            public static IEnumerable<ExcelPredefineStyle> RunReportPredefineStyles
            {
                get { return new[] { HeaderStyle, LightHeaderStyle, DataCellStyle, EmptyCellStyle, CourierNewFontCellStyle }; }
            }

            public static IEnumerable<ExcelPredefineStyle> SmoothFailuresReportPredefineStyles
            {
                get { return new[] { HeaderStyle, LightHeaderStyle, DataCellStyle, EmptyCellStyle }; }
            }

            public static IEnumerable<ExcelPredefineStyle> RecommendationReportPredefineStyles
            {
                get { return new[] { HeaderStyle, LightHeaderStyle, DataCellStyle, EmptyCellStyle }; }
            }

            public static Color[] AlternateBackgroundColors => new[] { Color.FromArgb(0xF5, 0xF5, 0xF5), Color.Transparent };
        }

        public static class ReportFormatter
        {
            private const string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            private const string DateFormat = "dd/MM/yyyy";
            private const string TimeFormat = @"hh\:mm\:ss";

            public static string ConvertToDateTime(object dateTime) =>
                ((DateTime)dateTime).ToUniversalTime().ToString(DateTimeFormat);

            public static string ConvertToShortDate(object dateTime) =>
                dateTime != null ? ((DateTime)dateTime).ToUniversalTime().ToString(DateFormat) : string.Empty;

            public static string ConvertToTime(object timeSpan) =>
                ((TimeSpan)timeSpan).ToString(TimeFormat);

            public static string DecimalRoundingFormatter(object rawValue) =>
                rawValue is decimal value
                    ? Math.Round(value, 2).ToString(CultureInfo.InvariantCulture)
                    : string.Empty;
        }
    }
}
