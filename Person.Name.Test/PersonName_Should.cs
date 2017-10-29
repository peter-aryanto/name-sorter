using System;
using Xunit;
using System.Collections.Generic;

namespace Person.Name.Test
{
  public class PersonName_Should
  {
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("          ")]
    [InlineData("\t")]
    [InlineData("\t\t\t")]
    [InlineData("\t \t \t ")]
    public void ThrowInvalidPersonNameExceptionGivenEmptyFullName(string fullName)
    {
      Assert.Throws<InvalidPersonNameException>(() => new PersonName(fullName));
    }

    [Theory]
    [InlineData(" John")]
    [InlineData("   John")]
    [InlineData("John ")]
    [InlineData("John  ")]
    [InlineData(" John ")]
    [InlineData("   John   ")]
    public void ThrowInvalidPersonNameExceptionGivenNotAtLeastOneGivenNameAndOneLastName(
      string fullName
    )
    {
      Assert.Throws<InvalidPersonNameException>(() => new PersonName(fullName));
    }

    [Theory]
    [InlineData("John Joe Doe Bob Smith")]
    public void ThrowInvalidPersonNameExceptionGivenMoreThanThreeGivenNamesAndOneLastName(
      string fullName
    )
    {
      Assert.Throws<InvalidPersonNameException>(() => new PersonName(fullName));
    }

    [Theory]
    [InlineData("John Smith")]
    [InlineData(" John Smith ")]
    [InlineData("   John Smith   ")]
    [InlineData("John   Smith")]
    [InlineData(" John   Smith ")]
    [InlineData("   John   Smith   ")]
    public void SuccessfullyCreatePersonGivenOneGivenNameAndOneLastName(string fullName)
    {
      const string inputGivenName = "John";
      const string inputLastName = "Smith";

      PersonName personName = new PersonName(fullName);
      
      Assert.Equal(inputGivenName, personName.GivenNames);
      Assert.Equal(inputLastName, personName.LastName);
    }

    [Theory]
    [InlineData("John Joe Doe Smith")]
    public void SuccessfullyCreatePersonGivenUpToThreeGivenNamesAndOneLastName(string fullName)
    {
      const string inputGivenNames = "John Joe Doe";
      const string inputLastName = "Smith";

      PersonName personName = new PersonName(fullName);
      
      Assert.Equal(inputGivenNames, personName.GivenNames);
      Assert.Equal(inputLastName, personName.LastName);
    }

    [Fact]
    public void ComparePersonNamesByLastNameThenByGivenNamesAscendingCaseInsensitive()
    {
      List<PersonName> personNameListToSort = new List<PersonName>();
      personNameListToSort.Add(new PersonName("Janet Parsons")); // will be number 4
      personNameListToSort.Add(new PersonName("Adonis Julius Archer")); // will be number 1
      personNameListToSort.Add(new PersonName("John deSouza")); // will be number 3
      personNameListToSort.Add(new PersonName("Hunter Uriah Mathew Clarke")); // will be number 2

      personNameListToSort.Sort(
        PersonName.ComparePersonNamesByLastNameThenByGivenNamesAscendingCaseInsensitive
      );

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
