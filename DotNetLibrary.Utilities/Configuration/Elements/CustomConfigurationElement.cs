using System;
using System.Configuration;
using System.Diagnostics.Contracts;

namespace DotNetLibrary.Utilities.Configuration.Elements
{
    /// <summary>
    /// Represents a custom node that can be used to contain custom settings. 
    /// </summary>
    public sealed class CustomConfigurationElement : ConfigurationElement   
    {
        /// <summary>
        /// Name attribute. This is the Key
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "What is the key name of this attribute?")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Value attribute
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true, DefaultValue = "What is the value of this attribute?")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        /// <summary>
        /// Description attribute. Very useful for documenting the node
        /// </summary>
        [ConfigurationProperty("description", IsRequired = true, DefaultValue = "What is the purpose of this attribute?")]
        public string Description
        {
            get { return (string)this["description"]; }
            set { this["description"] = value; }
        }
    }

    /// <summary>
    /// Represents a collection of custom configuration properties
    /// </summary>
    public sealed class CustomConfigurationElementCollection : ConfigurationElementCollection  
    {

        /// <summary>
        /// Indexer to return a specific element
        /// </summary>
        /// <param name="index">The index of the element in the collection</param>
        public CustomConfigurationElement this[int index]
        {
            get { return (CustomConfigurationElement)BaseGet(index); }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Removes the element from the collection.
        /// </summary>
        /// <param name="customConfigurationElement"></param>
        public void Remove(CustomConfigurationElement customConfigurationElement)
        {
            Contract.Requires<ArgumentNullException>(customConfigurationElement != null);
            BaseRemove(customConfigurationElement.Name);
        }

        /// <summary>
        /// Removes an element at a given index.
        /// </summary>
        /// <param name="index">The index of the element in the collection.</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Removes an element by name from the collection.
        /// </summary>
        /// <param name="name">the key of the element</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// Creates a new element
        /// </summary>
        /// <returns>Returns the newley created element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomConfigurationElement();
        }

        /// <summary>
        /// Returns an elemnt's key from the collection
        /// </summary>
        /// <param name="element">The element we are interested in.</param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomConfigurationElement)element).Name;
        }
    }
}
