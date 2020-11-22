using System;
using System.Linq;
using DemoLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var da = new DataAccesss();
            var people = da.GetPeople(3);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
