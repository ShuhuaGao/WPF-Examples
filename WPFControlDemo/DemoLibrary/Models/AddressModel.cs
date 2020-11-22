using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string FullAddress => $"{StreetAddress}, {City}, {State}, {ZipCode}";
    }
}
