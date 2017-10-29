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
      throw new NotImplementedException("There has been no implementation yet.");
    }

    private string[] GetAllNameParts(string fullName)
    {
      throw new NotImplementedException("There has been no implementation yet.");
    }

    private void FullNameMustHaveAtLeastOneGivenNameAndOneLastName(string[] nameParts)
    {
      throw new NotImplementedException("There has been no implementation yet.");
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
