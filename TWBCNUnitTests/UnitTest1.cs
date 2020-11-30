using Newtonsoft.Json;
using NUnit.Framework;
using System.Xml;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test_GetCountry_With_Valid_ISO()
        {
            string input = "GB";
            TheWorldBankCountries.Country result = TheWorldBankCountries.GetCountryClass.GetCountry(input);
            TheWorldBankCountries.Country excpectedResult = new TheWorldBankCountries.Country()
            {
                iso2Code = "GB",
                name = "United Kingdom",
                region = "Europe & Central Asia",
                capitalCity = "London",
                longitude = "-0.126236",
                latitude = "51.5002"
            };

            //for some reason if I dont serialize objects before comparing the test will fail, there is probably a better way of doing this
            var excpectedResultJson = JsonConvert.SerializeObject(excpectedResult);
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(excpectedResultJson, resultJson);
        }

        [Test]
        public void Test_GetCountry_With_Invalid_ISO()
        {
            string input = "123";
            TheWorldBankCountries.Country result = TheWorldBankCountries.GetCountryClass.GetCountry(input);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Test_GetCountry_With_No_Input()
        {
            string input = "";
            TheWorldBankCountries.Country result = TheWorldBankCountries.GetCountryClass.GetCountry(input);
            Assert.AreEqual(null, result);
        }
    }
}


