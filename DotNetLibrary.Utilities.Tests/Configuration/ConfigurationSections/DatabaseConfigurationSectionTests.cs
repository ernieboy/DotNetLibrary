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
            
            //Act
            string queryOneValue = DatabaseSettings.GetSqlQueryValueByName("CustomQuery1");
            string queryOneDescription = DatabaseSettings.GetSqlQueryDescriptionByName("CustomQuery1");

            int maximumNumberOfItemstoReturnFromAllQueries = 
                DatabaseSettings.GetSqlQueryValueAsIntByName("MaximumNumberOfItemstoReturnFromAllQueries");
            string maximumNumberOfItemstoReturnFromAllQueriesDescription =
                DatabaseSettings.GetSqlQueryDescriptionByName("MaximumNumberOfItemstoReturnFromAllQueries");


            //Assert
            Assert.That(queryOneValue, Is.EqualTo("SELECT * FROM DUAL"));
            Assert.That(queryOneDescription, Is.EqualTo("Lists all objects from the DUAL table"));
            Assert.That(maximumNumberOfItemstoReturnFromAllQueries, Is.EqualTo(300000));
            Assert.That(maximumNumberOfItemstoReturnFromAllQueriesDescription, 
                Is.EqualTo("This limits the maximum number of items that can be returned by some stored procedures. It's to stop clients from requesting too much data and crashing our servers."));
        }
    }
}
