using System;
using System.IO;
using System.Collections.Generic;
using Person.Name;

namespace MainProgram
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length != 1)
      {
        Console.WriteLine("Please execute: name-sorter [text-file-path-and-name]");
        return;
      }

      List<PersonName> personNameListToSort = ImportPersonNamesFromTextFile(
        args[0]
      );

      if (personNameListToSort == null || personNameListToSort.Count == 0)
      {
        Console.WriteLine("Program is stopped. No data to process.");
        return;
      }

      personNameListToSort.Sort(
        PersonName.ComparePersonNamesByLastNameThenByGivenNamesAscendingCaseInsensitive
      );

      ExportPersonNamesToTextFile(personNameListToSort, "sorted-names-list.txt", true);
    }

    private static List<PersonName> ImportPersonNamesFromTextFile(string textFilePathAndName)
    {
      string textLine;
      PersonName personName;
      List<PersonName> personNameList = new List<PersonName>();

      StreamReader textFileReader = null;
      try
      {
        textFileReader = new StreamReader(textFilePathAndName);

        while((textLine = textFileReader.ReadLine()) != null)
        {
          try
          {
            personName = new PersonName(textLine);
            personNameList.Add(personName);
          }
          catch (InvalidPersonNameException e)
          {
            Console.WriteLine("Skipping 1 invalid person name:");
            Console.WriteLine(e.Message);
          }
        }
      }
      catch (IOException e)
      {
        Console.WriteLine("The file could not be read due to IOException:");
        Console.WriteLine(e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
      }
      finally
      {
        if (textFileReader != null)
        {
          textFileReader.Close();
        }
      }

      return personNameList;
    }

    private static void ExportPersonNamesToTextFile(
      List<PersonName> personNamesList,
      string textFilePathAndName,
      bool displayPersonNamesOnScreen
    )
    {
      string personFullName;

      StreamWriter textFileWriter = null;
      try
      {
        textFileWriter = new StreamWriter(textFilePathAndName);

        foreach (PersonName personName in personNamesList)
        {
          personFullName = personName.GivenNames + " " + personName.LastName;

          if (displayPersonNamesOnScreen)
          {
            Console.WriteLine(personFullName);
          }

          textFileWriter.WriteLine(personFullName);
        }
      }
      catch (IOException e)
      {
        Console.WriteLine("The file could not be written due to IOException:");
        Console.WriteLine(e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("The file could not be written:");
        Console.WriteLine(e.Message);
      }
      finally
      {
        if (textFileWriter != null)
        {
          textFileWriter.Close();
        }
      }
   }
  }
}
