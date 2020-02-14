using System;
using System.Collections.Generic;
using System.Linq;

namespace TopTenPops
{
  class Program
  {
    static void Main(string[] args)
    {
      string filePath = @"./Pop by Largest Final.csv";

      CsvReader reader = new CsvReader(filePath);
      var countries = reader.ReadAllCountries();

      foreach (var region in countries.Keys)
      {
        Console.WriteLine(region);
      }

      Console.WriteLine("WHich of the above regions do you want?");

      string chosenRegion = Console.ReadLine();

      if (countries.ContainsKey(chosenRegion))
      {
        foreach (var country in countries[chosenRegion].Take(10))
        {
          Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");

        }
      }
      else
      {
        Console.WriteLine("That is not a valid region");
      }

      // Country lilliput = new Country("Lilliput", "LIL", "SomeWhere", 2_000_000);

      // int lilliputIndex = countries.FindIndex(x => x.Population < lilliput.Population);
      // countries.Insert(lilliputIndex, lilliput);
      // countries.RemoveAt(lilliputIndex);

      // Console.WriteLine("Enter number of countries to display");

      // bool inputIsInt = int.TryParse(Console.ReadLine(), out int input);

      // if (!inputIsInt || input <= 0)
      // {
      //   Console.WriteLine("You must type in a positive integer. Exiting");
      // }

      // // int max = Math.Min(input, countries.Count);
      // int max = input;
      // foreach (Country country in countries.Where(x => !x.Name.Contains(",")).Take(10))
      // for (int i = 0; i < countries.Count; i++)
      // {

      // if (i > 0 && (i % max) == 0)
      // {
      //   Console.WriteLine("Hit return to continue, anything else to quit");
      //   if (Console.ReadLine() != "")
      //   {
      //     break;
      //   }
      // }
      // Country country = countries[i];
      // }

      // Console.WriteLine("Which country code do you want to look up?");

      // string input = Console.ReadLine();

      // bool gotCountry = countries.TryGetValue(input.ToUpper(), out Country country);

      // if (!gotCountry)
      // {
      //   Console.WriteLine($"Sorry, there is no country with code {input}");
      // }
      // else
      // {
      //   Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
      // }


      // Console.WriteLine($"{countries.Count} countries");
    }
  }
}
