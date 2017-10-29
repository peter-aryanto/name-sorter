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
      List<PersonName> personNameListToSort = ImportPersonNamesFromTextFile(
        "unsorted-names-list.txt"
      );

      PersonNameSorter personNameSorter = new PersonNameSorter();
      personNameSorter.CaseInsensitiveSort(personNameListToSort);

      ExportPersonNamesToTextFile(personNameListToSort, "sorted-names-list.txt", true);
    }

    private static List<PersonName> ImportPersonNamesFromTextFile(string textFilePathAndName)
    {
      string textLine;
      PersonName personName;
      List<PersonName> personNameList = new List<PersonName>();

      StreamReader textFileReader = new StreamReader(textFilePathAndName);
      try
      {
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

      StreamWriter textFileWriter = new StreamWriter(textFilePathAndName);
      try
      {
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
