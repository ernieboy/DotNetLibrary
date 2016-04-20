using System;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using DotNetLibrary.Utilities.Configuration.ConfigurationSections;
using DotNetLibrary.Utilities.Configuration.Elements;

namespace DotNetLibrary.Utilities.Configuration
{
    /// <summary>
    ///  This class allows us to read configuration properties from the custom configuration sections in our config file.
    /// </summary>
    public static class CustomConfigurationSettings
    {
        private static readonly DatabaseConfigurationSection DatabaseConfigurationSection;
        private static readonly CustomAppSettingsConfigurationSection CustomAppSettingsConfigurationSection;

        /// <summary>
        /// Static constructor - reads the custom configuration sections from the config file and has it ready for use
        /// </summary>
        static CustomConfigurationSettings()
        {
            DatabaseConfigurationSection =
               (DatabaseConfigurationSection)ConfigurationManager.GetSection("databasePropertiesSettings");
            Debug.Assert(DatabaseConfigurationSection != null, "DatabaseConfigurationSection may not be null.");

            CustomAppSettingsConfigurationSection =
               (CustomAppSettingsConfigurationSection)ConfigurationManager.GetSection("customAppSettings");
            Debug.Assert(CustomAppSettingsConfigurationSection != null, "CustomAppSettingsConfigurationSection may not be null.");
        }

        /// <summary>
        /// Searches for a configuration element by name key from the configuration section.
        /// </summary>
        /// <param name="name">The Value of the "name" attribute in one of the child nodes of the custom configuration section.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>An CustomConfigurationElement whose name key Value matches the supplied name</returns>
        private static CustomConfigurationElement GetConfigurationElementByName(string name, CustomSections section)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), "Preconditions, name parameter may not be null.");
            Contract.Requires<ArgumentNullException>(DatabaseConfigurationSection != null, "Preconditions, DatabaseConfigurationSection may not be null.");
            Contract.Requires<ArgumentNullException>(CustomAppSettingsConfigurationSection != null, 
                "Preconditions, CustomAppSettingsConfigurationSection may not be null.");

            CustomConfigurationElement element = null;
            switch (section)
            {
                case CustomSections.Database:
                    element = DatabaseConfigurationSection.CustomConfigurations.Cast<CustomConfigurationElement>().
                Single(e => e.Name == name.Trim());
                    break;
                case CustomSections.AppSettings:
                    element = CustomAppSettingsConfigurationSection.CustomConfigurations.Cast<CustomConfigurationElement>().
                Single(e => e.Name == name.Trim());
                    break;
            }
            return element;
        }

        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Value attribute of that element
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>The Value attribute of the node which matches the key we are interested in.</returns>
        public static string GetElementValueByName(string uniqueKey, CustomSections section) 
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(uniqueKey), "Preconditions, name parameter may not be null.");

            CustomConfigurationElement element = GetConfigurationElementByName(uniqueKey, section);
            Contract.Assert(element != null, "element == null");
            string value = element.Value;
            return value;
        }

        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Value attribute of that element as an int
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>An integer converted from the Value attribute of the node which matches the key we are interested in.</returns>
        public static int GetElementValueAsIntByName(string uniqueKey, CustomSections section)   
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(uniqueKey), "Preconditions, name parameter may not be null.");
            string value = GetElementValueByName(uniqueKey, section);
            return int.Parse(value);
        }


        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Description attribute of that element
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>The Description attribute value of the node which matches the key we are interested in.</returns>
        public static string GetElementDescriptionByName(string uniqueKey, CustomSections section)   
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(uniqueKey), "Preconditions, name parameter may not be null.");

            CustomConfigurationElement element = GetConfigurationElementByName(uniqueKey, section);
            Contract.Assert(element != null, "element == null");
            string description = element.Description;
            return description;
        }
    }

    /// <summary>
    /// A enum which lists the available custom sections in our application
    /// </summary>
    public enum CustomSections
    {
        /// <summary>
        /// Teh database custom section.
        /// </summary>
        Database,

        /// <summary>
        /// the AppSettings custom section
        /// </summary>
        AppSettings
    }
}
