using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace DemoLibrary.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsAlive { get; set; }

        public decimal AccountBalance { get; set; }

        // auto-property initialization in C# 6
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        private AddressModel primaryAddress;
        public AddressModel PrimaryAddress
        {
            get
            {
                return primaryAddress ?? Addresses.FirstOrDefault();
            }
            set
            {
                primaryAddress = value;
                Debug.WriteLine($"--- {FullName}'s primary address set to {value.FullAddress}");
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return $"{PersonId} {FullName} {Age} {(IsAlive ? "Alive" : "Dead")}\n {Addresses.FirstOrDefault()?.FullAddress}\n";
        }


    }
}
