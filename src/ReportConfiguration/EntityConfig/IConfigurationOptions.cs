namespace ReportSystem.ReportConfiguration.EntityConfig
{
    public interface IConfigurationOptions
    {
        bool IsHideHeader { get; set; }

        bool UseHeaderHumanizer { get; set; }
    }
}
