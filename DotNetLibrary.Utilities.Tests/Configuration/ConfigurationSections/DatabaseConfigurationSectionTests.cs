using DotNetLibrary.Utilities.Configuration;
using NUnit.Framework;

namespace DotNetLibrary.Utilities.Tests.Configuration.ConfigurationSections
{
    [TestFixture]
    public sealed class DatabaseConfigurationSectionTests
    {
        [Test]
        public void TestIfWeCanReadTheCustomDatabasePropertiesFromTheConfigurationFile()
        {
            //Arrange
            ICustomConfigurationSettings customSettings = new CustomConfigurationSettings();

            //Act
            string queryOneValue = customSettings.GetElementValueByName("CustomQuery1", CustomSections.Database);
            string queryOneDescription = customSettings.GetElementDescriptionByName("CustomQuery1", CustomSections.Database);

            int maximumNumberOfItemstoReturnFromAllQueries =
                customSettings.GetElementValueAsIntByName("MaximumNumberOfItemstoReturnFromAllQueries", CustomSections.Database);
            string maximumNumberOfItemstoReturnFromAllQueriesDescription =
                customSettings.GetElementDescriptionByName("MaximumNumberOfItemstoReturnFromAllQueries", CustomSections.Database);


            //Assert
            Assert.That(queryOneValue, Is.EqualTo("SELECT * FROM DUAL"));
            Assert.That(queryOneDescription, Is.EqualTo("Lists all objects from the DUAL table"));
            Assert.That(maximumNumberOfItemstoReturnFromAllQueries, Is.EqualTo(300000));
            Assert.That(maximumNumberOfItemstoReturnFromAllQueriesDescription,
                Is.EqualTo("This limits the maximum number of items that can be returned by some stored procedures. It's to stop clients from requesting too much data and crashing our servers."));
        }


        [Test]
        public void TestIfWeCanReadTheCustomPropertiesFromTheConfigurationFile()    
        {
            //Arrange
            ICustomConfigurationSettings customSettings = new CustomConfigurationSettings();

            //Act
            string searchUrlValue = customSettings.GetElementValueByName("SearchUrl", CustomSections.AppSettings);
            int mailServerPort = customSettings.GetElementValueAsIntByName("MailServerPort", CustomSections.AppSettings);
            string mailServerPortDescription = customSettings.GetElementDescriptionByName("MailServerPort", CustomSections.AppSettings);

            //Assert
            Assert.That(searchUrlValue, Is.EqualTo("http://www.google.com?search=computers"));
            Assert.That(mailServerPort, Is.EqualTo(38));
            Assert.That(mailServerPortDescription, Is.EqualTo("This is the port of the mail server in the network."));

        }
    }
}
