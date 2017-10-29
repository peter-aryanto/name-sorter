using System;

namespace Person.Name
{
    public class InvalidPersonNameException: Exception
    {
      public InvalidPersonNameException()
      {
      }

      public InvalidPersonNameException(string message)
          : base(message)
      {
      }

      public InvalidPersonNameException(string message, Exception inner)
          : base(message, inner)
      {
      }
    }
}
