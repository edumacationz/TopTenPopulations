
using System;
using System.Collections.Generic;
using System.IO;

namespace TopTenPops
{
  class CsvReader
  {
    private string _csvFilePath;

    public CsvReader(string csvFilePath)
    {
      _csvFilePath = csvFilePath;
    }

    public void RemoveCommaCountries(List<Country> countries)
    {
      // for (int i = countries.Count; i >= 0; i--)
      // {
      //   if (countries[1].Name.Contains(","))
      //   {
      //     countries.RemoveAt(i);
      //   }
      // }

      countries.RemoveAll(x => x.Name.Contains("<"));
    }

    // public Dictionary<string, Country> ReadAllCountries()
    // {
    //   var countries = new Dictionary<string, Country>();

    //   using (StreamReader stream = new StreamReader(_csvFilePath))
    //   {
    //     stream.ReadLine();

    //     string line;
    //     while ((line = stream.ReadLine()) != null)
    //     {
    //       var country = ReadCountryFromCsvLine(line);
    //       countries.Add(country.Code, country);
    //     }

    //   }

    //   return countries;
    // }

    public Dictionary<string, List<Country>> ReadAllCountries()
    {
      var countries = new Dictionary<string, List<Country>>();

      using (StreamReader stream = new StreamReader(_csvFilePath))
      {
        stream.ReadLine();

        string line;
        while ((line = stream.ReadLine()) != null)
        {
          var country = ReadCountryFromCsvLine(line);

          if (!countries.ContainsKey(country.Region))
          {
            countries.Add(country.Region, new List<Country>());
          }
          countries[country.Region].Add(country);
        }

      }

      return countries;
    }

    private static Country ReadCountryFromCsvLine(string csvLine)
    {
      string[] parts = csvLine.Split(',');
      string name;
      string code;
      string region;
      string popText;

      switch (parts.Length)
      {
        case 4:
          name = parts[0];
          code = parts[1];
          region = parts[2];
          popText = parts[3];
          break;
        case 5:
          name = (parts[0] + ", " + parts[1]).Replace("\"", null).Trim();
          code = parts[2];
          region = parts[3];
          popText = parts[4];
          break;
        default:
          throw new Exception($"Can't paarse country from line: {csvLine}");
      }

      int.TryParse(popText, out int population);

      return new Country(name, code, region, population);


    }

  }
}
