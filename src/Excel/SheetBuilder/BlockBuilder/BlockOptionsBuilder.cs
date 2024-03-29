﻿using System.Drawing;
using ReportSystem.Excel.ExcelReportConfiguration.Styles;
using ReportSystem.Excel.ExcelReportConfiguration.Styles.Enums;

namespace ReportSystem.Excel.SheetBuilder.BlockBuilder
{
    public class BlockOptionsBuilder<T> : IBlockOptionsBuilder
    {
        private BlockOptions<T> Options { get; } = new BlockOptions<T>();

        public BlockOptionsBuilder(T value)
        {
            Options.Value = value;
        }

        public IBlockOptionsBuilder Display(DisplayType display)
        {
            Options.Display = display;
            return this;
        }

        public IBlockOptionsBuilder ColSpan(int colSpan)
        {
            Options.ColSpan = colSpan;
            return this;
        }

        public IBlockOptionsBuilder RowSpan(int rowSpan)
        {
            Options.RowSpan = rowSpan;
            return this;
        }

        public IBlockOptionsBuilder Background(Color color)
        {
            Options.BackgroundColor = color;
            return this;
        }

        public IBlockOptionsBuilder HAlign(ExcelHorizontalAlignment alignment)
        {
            Options.HAlign = alignment;
            return this;
        }

        public IBlockOptionsBuilder VAlign(ExcelVerticalAlignment alignment)
        {
            Options.VAlign = alignment;
            return this;
        }

        public IBlockOptionsBuilder Style(ExcelStyle style)
        {
            Options.Style = style;
            return this;
        }

        public IBlockOptionsBuilder Style(string styleName)
        {
            Options.StyleName = styleName;
            return this;
        }

        public IBlockOptionsBuilder Style(ExcelPredefineStyle predefineStyle)
        {
            Options.StyleName = predefineStyle.Name;
            return this;
        }

        public IBlockOptions Build()
        {
            return Options;
        }
    }
}
