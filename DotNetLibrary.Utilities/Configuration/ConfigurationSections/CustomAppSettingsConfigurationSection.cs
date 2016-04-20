using System.Configuration;
using DotNetLibrary.Utilities.Configuration.Elements;

namespace DotNetLibrary.Utilities.Configuration.ConfigurationSections
{
    /// <summary>
    /// This class represents a custom application settings configuration section. 
    /// This is slightly better than the build in application settings because each item now includes a "description"
    /// property which is great for documenting the property. 
    /// </summary>
    /// <example>
    /// <configuration>
    ///     <configSections>
    ///         <section name="customAppSettings" type="DotNetLibrary.Utilities.Configuration.ConfigurationSections.CustomAppSettingsConfigurationSection,DotNetLibrary.Utilities, Version=1.0.0.0, Culture=neutral" allowLocation="true" allowDefinition="Everywhere"/>
    ///     </configSections>
    ///     <customAppSettings description="This section contains custom application settings such as URLs of web services.">
    ///         <applicationProperties>
    ///             <add name = "SearchUrl" value="http://www.google.com?search=computers" description="Contains the search URL for the websites search section." />
    ///             <add name = "MailServerPort" value="38" description="This is the port of the mail server in the network." />
    ///         </applicationProperties>
    ///    </customAppSettings>
    /// </configuration>
    /// </example>
    public sealed class CustomAppSettingsConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// This is the description attribute of the custom application settings configuration section
        /// </summary>
        [ConfigurationProperty("description",
            DefaultValue = "This section contains configuration information about our custom applications settings such as URLs for external services.",
            IsRequired = true)]
        public string Description
        {
            get
            {
                return (string)this["description"];
            }
            set
            {
                this["description"] = value;
            }
        }

        /// <summary>
        /// Returns a collection of application configuration properties
        /// </summary>
        [ConfigurationProperty("applicationProperties", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CustomConfigurationElementCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CustomConfigurationElementCollection CustomConfigurations => (CustomConfigurationElementCollection)base["applicationProperties"];
    }
}
