namespace DotNetLibrary.Utilities.Configuration
{
    public interface ICustomConfigurationSettings
    {
        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Value attribute of that element
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>The Value attribute of the node which matches the key we are interested in.</returns>
        string GetElementValueByName(string uniqueKey, CustomSections section);

        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Value attribute of that element as an int
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>An integer converted from the Value attribute of the node which matches the key we are interested in.</returns>
        int GetElementValueAsIntByName(string uniqueKey, CustomSections section);

        /// <summary>
        /// Searches for a CustomConfigurationElement by key from the config section and returns the Description attribute of that element
        /// </summary>
        /// <param name="uniqueKey">The key of the the child node we are interested in.</param>
        /// <param name="section">The custom configuration section we are interested in.</param>
        /// <returns>The Description attribute value of the node which matches the key we are interested in.</returns>
        string GetElementDescriptionByName(string uniqueKey, CustomSections section);
    }
}