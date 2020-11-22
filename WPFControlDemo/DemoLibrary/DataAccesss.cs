using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using DemoLibrary.Models;


namespace DemoLibrary
{
    public class DataAccesss
    {
        private Random rnd = new Random();
        private string[] streetAddresses = {
            "6649 N Blue Gum St",
            "2 Cedar Ave #84",
            "386 9th Ave N",
            "74874 Atlantic Ave",
            "366 South Dr",
            "45 E Liberty St",
            "4 Ralph Ct",
            "2742 Distribution Way",
            "426 Wolf St",
            "5 N Cleveland Massillon Rd"
        };
        private string[] cities = {
            "Brighton",
            "Anchorage",
            "Flemington",
            "Westbury",
            "Jenkintown",
            "Van Nuys",
            "Providence",
            "Huntingdon Valley",
            "Providence",
            "Monroe Township",
            "Austin",
            "Littleton",
            "Milwaukee",
            "New York"
        };
        private string[] states =
        {
            "CA",
            "SD",
            "MD",
            "PA",
            "OH",
            "TX",
            "NM",
            "NY",
            "KS",
            "OR"
        };
        private string[] zipCodes = {
            "70116",
            "48116",
            "8014",
            "99501",
            "45011",
            "44805",
            "60632",
            "95111",
            "57105",
            "21224",
            "19443",
            "11953",
            "90034",
            "10025",
        };

        private string[] firstNames =
        {
            "Graciela",
            "Cammy",
            "Mattie",
            "Meaghan",
            "Gladys",
            "Yuki",
            "Fletcher",
            "Bette",
            "Veronika",
            "Willard",
            "Maryann",
            "Alisha",
            "Erick"
        };
        private string[] lastNames =
        {
            "Inouye",
            "Kolmetz",
            "Royster",
            "Slusarski",
            "Iturbide",
            "Caudy",
            "Chui",
            "Kusko",
            "Figeroa",
            "Corrio",
            "Vocelka",
            "Stenseth",
            "Glick"
        };

        private bool[] aliveStatuses = { true, false };
        private DateTime lowEndDate = new DateTime(1943, 1, 1);
        private int daysFromLowDate;

        public DataAccesss()
        {
            daysFromLowDate = (DateTime.Today - lowEndDate).Days;
        }

        public string[] StreeAddresses => streetAddresses;

        private PersonModel GetPerson(int id)
        {
            var randomDate = GetRandomDate();
            var p = new PersonModel
            {
                PersonId = id,
                FirstName = GetRandomItem(firstNames),
                LastName = GetRandomItem(lastNames),
                IsAlive = GetRandomItem(aliveStatuses),
                DateOfBirth = randomDate,
                Age = GetAgeInYears(randomDate),
                AccountBalance = (decimal)(rnd.Next(1, 100000) / 100)
            };

            var addressCount = rnd.Next(1, 5);
            for (int i = 0; i < addressCount; i++)
            {
                p.Addresses.Add(GetAddress((id - 1) * 5 + i + 1));
            }
            return p;
        }


        private T GetRandomItem<T>(T[] data) => data[rnd.Next(0, data.Length)];

        private DateTime GetRandomDate() => lowEndDate.AddDays(rnd.Next(daysFromLowDate));

        private int GetAgeInYears(DateTime birthday)
        {
            var diff = DateTime.Now - birthday;
            return (int)(diff.Days / 365); // truncate
        }

        private AddressModel GetAddress(int id) => new AddressModel
        {
            AddressId = id,
            StreetAddress = GetRandomItem(streetAddresses),
            City = GetRandomItem(cities),
            State = GetRandomItem(states),
            ZipCode = GetRandomItem(zipCodes)
        };

        public List<PersonModel> GetPeople(int total = 10)
        {
            var people = new List<PersonModel>();
            for (int i = 0; i < total; i++)
                people.Add(GetPerson(i + 1));
            return people;
        }
    }
}
