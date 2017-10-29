using System;
using Xunit;

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
    public void SuccessfullyCreatePersonGivenOneGivenNameAndOneLastName(
      string fullName
    )
    {
      const string inputGivenName = "John";
      const string inputLastName = "Smith";

      PersonName personName = new PersonName(fullName);
      
      Assert.Equal(inputGivenName, personName.GivenNames);
      Assert.Equal(inputLastName, personName.LastName);
    }

    [Theory]
    [InlineData("John Joe Doe Smith")]
    public void SuccessfullyCreatePersonGivenUpToThreeGivenNamesAndOneLastName(
      string fullName
    )
    {
      const string inputGivenNames = "John Joe Doe";
      const string inputLastName = "Smith";

      PersonName personName = new PersonName(fullName);
      
      Assert.Equal(inputGivenNames, personName.GivenNames);
      Assert.Equal(inputLastName, personName.LastName);
    }
  }
}
