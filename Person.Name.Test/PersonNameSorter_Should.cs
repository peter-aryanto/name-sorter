using System;
using Xunit;
using System.Collections.Generic;

namespace Person.Name.Test
{
  public class PersonNameSorter_Should
  {
    [Fact]
    public void ReturnCaseInsensitiveSortedPersonNameGivenListOfPersonName()
    {
      List<PersonName> personNameListToSort = new List<PersonName>();
      personNameListToSort.Add(new PersonName("Janet Parsons")); // will be number 4
      personNameListToSort.Add(new PersonName("Adonis Julius Archer")); // will be number 1
      personNameListToSort.Add(new PersonName("John deSouza")); // will be number 3
      personNameListToSort.Add(new PersonName("Hunter Uriah Mathew Clarke")); // will be number 2

      PersonNameSorter personNameSorter = new PersonNameSorter();
      personNameSorter.CaseInsensitiveSort(personNameListToSort);

      Assert.Equal("Adonis Julius", personNameListToSort[0].GivenNames);
      Assert.Equal("Archer", personNameListToSort[0].LastName);
      Assert.Equal("Hunter Uriah Mathew", personNameListToSort[1].GivenNames);
      Assert.Equal("Clarke", personNameListToSort[1].LastName);
      Assert.Equal("John", personNameListToSort[2].GivenNames);
      Assert.Equal("deSouza", personNameListToSort[2].LastName);
      Assert.Equal("Janet", personNameListToSort[3].GivenNames);
      Assert.Equal("Parsons", personNameListToSort[3].LastName);
    }
  }
}
