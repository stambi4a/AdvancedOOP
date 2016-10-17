namespace Problem_04.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        private static void Main(string[] args)
        {
            var phone = new SmartPhone();
            var phoneNumbers = Console.ReadLine().Split();
            phone.CallOtherSmartPhones(phoneNumbers);
            var siteNames = Console.ReadLine().Split();
            phone.BrowseSites(siteNames);
        }
    }

    public class SmartPhone : ICall, IBrowse
    {
        public SmartPhone()
        {
        }

        public void CallOtherSmartPhones(IReadOnlyList<string> phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                var regex = new Regex("^\\d+$");
                if (regex.IsMatch(number))
                {
                    Console.WriteLine("Calling... " + number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

        public void BrowseSites(IReadOnlyList<string> sitesNames)
        {
            var regex = new Regex("[^0-9]*[0-9]+.*");
            foreach (var site in sitesNames)
            {
                if (regex.IsMatch(site))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine("Browsing: " + site+"!");
                }
            }
        }
    }

    public interface ICall
    {
        void CallOtherSmartPhones(IReadOnlyList<string> phones);
    }

    public interface IBrowse
    {
        void BrowseSites(IReadOnlyList<string> sites);
    }
}
