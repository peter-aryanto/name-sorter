using System;

namespace Person.Name
{
  public class PersonName
  {
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
      const int requiredNoOfLastName = 1;

      if (nameParts.Length < (minNoOfGivenNames + requiredNoOfLastName))
      {
        throw new InvalidPersonNameException(
          "A person name must have at least 1 given name and 1 last name."
        );
      }
    }

    private void FullNameMayHaveUpToThreeGivenNamesAndOneLastName(string[] nameParts)
    {
      throw new NotImplementedException("There has been no implementation yet.");
    }

    private string GetGivenNamesFromFullName(string[] nameParts)
    {
      throw new NotImplementedException("There has been no implementation yet.");
    }
  }
}
