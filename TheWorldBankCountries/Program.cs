using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TheWorldBankCountries
{
    public static class GetCountryClass
    {
        public static Country GetCountry(string input)
        {
            //check for blank or spaces input
            if (!string.IsNullOrWhiteSpace(input))
            {
                //set the base URL
                string URL = "http://api.worldbank.org/v2/country";
                XNamespace wb = "http://www.worldbank.org";
                //add user's input to URL
                string isoURL = URL + "/" + input;
                XDocument doc = XDocument.Load(isoURL);
                //get info from URL and put into objects in a list
                Country.countries = doc.Descendants(wb + "country").Select(x => new Country()
                {
                    iso2Code = (string)x.Element(wb + "iso2Code"),
                    name = (string)x.Element(wb + "name"),
                    region = (string)x.Element(wb + "region"),
                    capitalCity = (string)x.Element(wb + "capitalCity"),
                    longitude = (string)x.Element(wb + "longitude"),
                    latitude = (string)x.Element(wb + "latitude")
                }).ToList();

                //if none is found, return null
                if (Country.countries.Count == 0)
                {
                    return null;
                }
                else
                {
                    //return the specific country
                    var foundCountry = Country.countries.First();
                    return foundCountry;
                }
            }
            else
            {
                //if input is blank or spaces, return null
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an ISO code...");
            string consoleInput = Console.ReadLine();

            
            if (consoleInput != "")
            {
                Country country = GetCountryClass.GetCountry(consoleInput);
                if (country != null)
                {
                    //display all properties of the country object
                    Console.WriteLine(country.name);
                    Console.WriteLine(country.region);
                    Console.WriteLine(country.capitalCity);
                    Console.WriteLine(country.longitude);
                    Console.WriteLine(country.latitude);
                }
                else
                {
                    Console.WriteLine("This ISO Code Is Not Valid or Does Not Exist");
                }
            }
            else
            {
                Console.WriteLine("You must enter a Value");
            }


            //---works, no tests---
            //string input = Console.ReadLine();
            //if (input != "")
            //{
            //    string URL = "http://api.worldbank.org/v2/country";
            //    XNamespace wb = "http://www.worldbank.org";
            //    string isoURL = URL + "/" + input;
            //    XDocument doc = XDocument.Load(isoURL);
            //    Country.countries = doc.Descendants(wb + "country").Select(x => new Country()
            //    {
            //        iso2Code = (string)x.Element(wb + "iso2Code"),
            //        name = (string)x.Element(wb + "name"),
            //        region = (string)x.Element(wb + "region"),
            //        capitalCity = (string)x.Element(wb + "capitalCity"),
            //        longitude = (string)x.Element(wb + "longitude"),
            //        latitude = (string)x.Element(wb + "latitude")
            //    }).ToList();

            //    if (Country.countries.Count == 0)
            //    {
            //        Console.WriteLine("This ISO Code Is Not Valid or Does Not Exist");
            //    }
            //    else
            //    {
            //        var foundCountry = Country.countries.First();
            //        Console.WriteLine(foundCountry.name);
            //        Console.WriteLine(foundCountry.region);
            //        Console.WriteLine(foundCountry.capitalCity);
            //        Console.WriteLine(foundCountry.longitude);
            //        Console.WriteLine(foundCountry.latitude);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("You must enter a Value");
            //}

            //---works but only for page 1 and probably not the best way to do it---
            //string URL = "http://api.worldbank.org/v2/country";
            //XNamespace wb = "http://www.worldbank.org";
            //XDocument doc = XDocument.Load(URL);
            //Country.countries = doc.Descendants(wb +  "country").Select(x => new Country()
            //{
            //    iso2Code = (string)x.Element(wb + "iso2Code"),
            //    name = (string)x.Element(wb + "name"),
            //    region = (string)x.Element(wb + "region"),
            //    capitalCity = (string)x.Element(wb + "capitalCity"),
            //    longitude = (string)x.Element(wb + "longitude"),
            //    latitude = (string)x.Element(wb + "latitude")
            //}).ToList();

            //string input = Console.ReadLine();
            //var foundCountry = Country.countries.First(o => o.iso2Code == input);
            //if (foundCountry != null)
            //{
            //    Console.WriteLine(foundCountry.name);
            //    Console.WriteLine(foundCountry.region);
            //    Console.WriteLine(foundCountry.capitalCity);
            //    Console.WriteLine(foundCountry.longitude);
            //    Console.WriteLine(foundCountry.latitude);
            //}
            //else
            //{
            //    Console.WriteLine("This ISO Code Does Not Exist");
            //}
            //Console.WriteLine(input);
        }
    }

    public class Country
    {
        public static List<Country> countries = new List<Country>();

        public string iso2Code { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string capitalCity { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
