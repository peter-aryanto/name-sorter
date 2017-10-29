using System;
using System.Collections.Generic;

namespace Person.Name
{
  public class PersonNameSorter
  {
    public void CaseInsensitiveSort(List<PersonName> personNameListToSort)
    {
      personNameListToSort.Sort(
        (personName1, personName2) => String.Compare(
          personName1.LastName + personName1.GivenNames,
          personName2.LastName + personName2.GivenNames,
          StringComparison.OrdinalIgnoreCase
        )
      );
    }
  }
}
