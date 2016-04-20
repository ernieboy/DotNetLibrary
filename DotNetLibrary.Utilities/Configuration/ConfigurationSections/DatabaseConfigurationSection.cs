using System.Configuration;
using DotNetLibrary.Utilities.Configuration.Elements;

namespace DotNetLibrary.Utilities.Configuration.ConfigurationSections
{
    /// <summary>
    /// This class allows us to create a new custome database configuration section in the configuration file. 
    /// </summary>
    /// <example>
    /// <configuration>
    ///     <configSections>
    ///         <section name="databasePropertiesSettings" type="DotNetLibrary.Utilities.Configuration.ConfigurationSections.DatabaseConfigurationSection,DotNetLibrary.Utilities, Version=1.0.0.0, Culture=neutral" allowLocation="true" allowDefinition="Everywhere"/>
    ///     </configSections>
    ///     <databasePropertiesSettings description="This section contains configuration information about our database such as Stored Procedure names.">
    ///         <databaseProperties>
    ///             <add name = "OrganisationHierarchyListStoredProcedure" value="Tsa_org_Hierarchy_Export" description="Lists TSA organisation hierarchy." />
    ///             <add name = "MaximumNumberOfItemstoReturnFromAllQueries" value="300000" description="This limits the maximum number of items that can be returned by some stored procedures. It's to stop clients from requesting too much data and crashing our servers." />
    ///         </databaseProperties>
    ///    </databasePropertiesSettings>
    /// </configuration>
    /// </example>
    public sealed class DatabaseConfigurationSection : ConfigurationSection
    {

        /// <summary>
        /// This is the description attibute of the database configuration section
        /// </summary>
        [ConfigurationProperty("description",
            DefaultValue = "This section contains configuration information about our database such as Stored Procedure names.",
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
        /// Returns a collection of database configuration properties
        /// </summary>
        [ConfigurationProperty("databaseProperties", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CustomConfigurationElementCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CustomConfigurationElementCollection CustomConfigurations => (CustomConfigurationElementCollection)base["databaseProperties"];
    }
}
