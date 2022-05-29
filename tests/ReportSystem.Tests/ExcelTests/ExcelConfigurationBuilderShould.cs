using System.Drawing;
using System.Linq;
using ReportSystem.Excel.ExcelReportConfiguration.EntityConfig;
using ReportSystem.Tests.ExcelTests.Helper;
using ReportSystem.Tests.SampleData;
using Xunit;

namespace ReportSystem.Tests.ExcelTests
{
    public class ExcelConfigurationBuilderShould
    {
        [Fact]
        public void CreateDefaultConfig()
        {
            ExcelReportConfiguration config = GetDefaultExcelConfig();

            Assert.NotNull(config);
        }

        [Fact]
        public void CreateDefaultConfig_AllMembersConfigured()
        {
            ExcelReportConfiguration config = GetDefaultExcelConfig();

            Assert.Equal(6, config.MemberConfigurations.GetActiveOrderlyOptions().Count());

        }

        [Fact]
        public void SetHideHeader()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>()
                .HideHeader();
            var config = configBuilder.BuildConfiguration();

            Assert.True(config.Options.IsHideHeader);
        }

        [Fact]
        public void SetIgnoreNotMapped()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>()
                .IgnoreNotDescribed();
            var config = configBuilder.BuildConfiguration();

            Assert.Empty(config.MemberConfigurations.GetActiveOrderlyOptions());
        }

        [Fact]
        public void SetHeaderStyle()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>()
                .HeaderStyle(DemoReportStyles.HeaderStyle.Style);
            var config = configBuilder.BuildConfiguration();

            Assert.NotNull(DemoReportStyles.HeaderStyle.Style);
            Assert.True(config.Options.IsSetHeaderStyle);
        }

        [Fact]
        public void SetAlternateBackgroundColors()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>()
                .AlternateBackgroundColors(new Color[] { Color.Red, Color.Green, Color.Blue});
            var config = configBuilder.BuildConfiguration();

            Assert.True(config.Options.HasAlternateBackgroundColor);
            Assert.Equal(3,config.Options.AlternateBackgroundColors.Count);
            Assert.Equal(Color.Red,config.Options.AlternateBackgroundColors[0].Value);
            Assert.Equal(Color.Green,config.Options.AlternateBackgroundColors[1].Value);
            Assert.Equal(Color.Blue,config.Options.AlternateBackgroundColors[2].Value);
        }

        [Fact]
        public void SetDefaultStyle()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>()
                .DefaultStyle(DemoReportStyles.DataCellStyle.Style);
            var config = configBuilder.BuildConfiguration();

            Assert.NotNull(DemoReportStyles.DataCellStyle.Style);
            Assert.True(config.Options.IsSetDefaultStyle);
        }

        [Fact]
        public void DefaultUseHeaderHumanize()
        {
            var config = GetDefaultExcelConfig();

            Assert.True(config.Options.UseHeaderHumanizer);
        }

        private static ExcelReportConfiguration GetDefaultExcelConfig()
        {
            var configBuilder = new ExcelConfigurationBuilder<SaleData>();
            var config = configBuilder.BuildConfiguration();
            return config;
        }
    }
}
