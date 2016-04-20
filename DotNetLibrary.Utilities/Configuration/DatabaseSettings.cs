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
    ///  This class allows us to read configuration properties from the custom database section in our config file.
    /// </summary>
    public static  class DatabaseSettings
    {
        private static readonly DatabaseConfigurationSection DatabaseConfigurationSection;

        /// <summary>
        /// Static constructor - reads the section databaseQueriesConfiguration section from the config file and has it ready for use
        /// </summary>
        static DatabaseSettings()
        {
            DatabaseConfigurationSection =
               (DatabaseConfigurationSection)ConfigurationManager.GetSection("databasePropertiesSettings");
            Debug.Assert(DatabaseConfigurationSection != null, "DatabaseConfigurationSection may not be null.");
        }

        /// <summary>
        /// Searches for a SqlQueryElement by name from the config file
        /// </summary>
        /// <param name="name">The value of the "name" attribute in one of the child nodes of <sqlQueries /> node e.g. MembersCountStoredProcedure</param>
        /// <returns>An SqlQueryElement that is one of the children of the <sqlQueries /> node</returns>
        private static DatabaseConfigurationElement GetSqlQueryElementByName(string name)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), "Preconditions, name parameter may not be null.");
            Contract.Requires<ArgumentNullException>(DatabaseConfigurationSection != null, "Preconditions, DatabaseConfigurationSection may not be null.");

            DatabaseConfigurationElement element = DatabaseConfigurationSection.DatabaseConfigurations.Cast<DatabaseConfigurationElement>().
                Single(e => e.Name == name.Trim());
            return element;
        }

        /// <summary>
        /// Searches for a SqlQueryElement by name from the config section and returns the string value of the Value attribute of that element
        /// </summary>
        /// <param name="name">The value of the "name" attribute in one of the child nodes of <sqlQueries /> node e.g. OrganisationHierarchyListStoredProcedure</param>
        /// <returns>A string which is the value of the Value attribute in the child node in <sqlQueries/> whose name attribute value matches the name argument</returns>
        public static string GetSqlQueryValueByName(string name)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), "Preconditions, name parameter may not be null.");

            DatabaseConfigurationElement element = GetSqlQueryElementByName(name);
            Contract.Assert(element != null, "element == null");
            string value = element.Value;
            return value;
        }

        /// <summary>
        /// Searches for a SqlQueryElement by name from the config section and returns the string value of the Value attribute of that element as an int
        /// </summary>
        /// <param name="name">The value of the "name" attribute in one of the child nodes of <sqlQueries /> node e.g. OrganisationHierarchyListStoredProcedure</param>
        /// <returns>An integer  converted from the string which is the value of the Value attribute in the child node in <sqlQueries/> whose name attribute value matches the name argument</returns>
        public static int GetSqlQueryValueAsIntByName(string name)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), "Preconditions, name parameter may not be null.");
            string value = GetSqlQueryValueByName(name);
            return int.Parse(value);
        }


        /// <summary>
        /// Searches for a SqlQueryElement by name from the config section and returns the string value of the Description attribute of that element
        /// </summary>
        /// <param name="name">The value of the "name" attribute in one of the child nodes of <sqlQueries /> node e.g. OrganisationHierarchyListStoredProcedure</param>
        /// <returns>A string which is the value of the Description attribute in the child node in <sqlQueries/> whose name attribute value matches the name argument</returns>
        public static string GetSqlQueryDescriptionByName(string name)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name), "Preconditions, name parameter may not be null.");

            DatabaseConfigurationElement element = GetSqlQueryElementByName(name);
            Contract.Assert(element != null, "element == null");
            string description = element.Description;
            return description;
        }
    }
}
