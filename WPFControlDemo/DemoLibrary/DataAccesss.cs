using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    public class DataAccesss
    {
        private Random rnd = new Random();
        private string[] streetAddresses;
        private string[] cities;
        private string[] states;
        private string[] zipCodes;

        private string[] firstNames;
        private string[] lastNames;

        private bool[] aliveStatuses = { true, false };
        private DateTime lowEndDate = new DateTime(1943, 1, 1);
        private int daysFromLowDate;

        public DataAccesss()
        {
            daysFromLowDate = (DateTime.Today - lowEndDate).Days;
            // read sample data from a CSV file

        }
    }
}
