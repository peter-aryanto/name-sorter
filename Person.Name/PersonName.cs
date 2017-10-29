using System;

namespace Person.Name
{
  public class PersonName
  {
    private const int requiredNoOfLastName = 1;

    public string GivenNames { get; }
    public string LastName { get; }

    public PersonName(string fullName)
    {
      FullNameCannotBeEmpty(fullName);

      string[] nameParts = GetAllNameParts(fullName);

      FullNameMustHaveAtLeastOneGivenNameAndOneLastName(nameParts);
      FullNameMayHaveUpToThreeGivenNamesAndOneLastName(nameParts);

      GivenNames = GetGivenNamesFromFullName(nameParts);
      LastName = nameParts[nameParts.Length - 1];
    }

    public static int ComparePersonNamesByLastNameThenByGivenNamesAscendingCaseInsensitive(
      PersonName personName1,
      PersonName personName2
    )
    {
      return String.Compare(
        personName1.LastName + personName1.GivenNames,
        personName2.LastName + personName2.GivenNames,
        StringComparison.OrdinalIgnoreCase
      );
    }

    private void FullNameCannotBeEmpty(string fullName)
    {
      if (String.IsNullOrWhiteSpace(fullName))
      {
        throw new InvalidPersonNameException("The full name of a person cannot be empty.");
      }
    }

    private string[] GetAllNameParts(string fullName)
    {
      char[] charSeparators = {' '};
      return fullName.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
    }

    private void FullNameMustHaveAtLeastOneGivenNameAndOneLastName(string[] nameParts)
    {
      const int minNoOfGivenNames = 1;

      if (nameParts.Length < (minNoOfGivenNames + requiredNoOfLastName))
      {
        throw new InvalidPersonNameException(
          "A person name must have at least 1 given name and 1 last name."
        );
      }
    }

    private void FullNameMayHaveUpToThreeGivenNamesAndOneLastName(string[] nameParts)
    {
      const int maxNoOfGivenNames = 3;

      if (nameParts.Length > (maxNoOfGivenNames + requiredNoOfLastName))
      {
        throw new InvalidPersonNameException(
          "A person name may have up to 3 given names and 1 last name."
        );
      }
    }

    private string GetGivenNamesFromFullName(string[] nameParts)
    {
      string givenNames = "";

      for (int index = 0; index < nameParts.Length - requiredNoOfLastName; index++) {
        if (index > 0)
        {
          givenNames = givenNames + " ";
        }

        givenNames = givenNames + nameParts[index];
      }

      return givenNames;
    }
  }
}
