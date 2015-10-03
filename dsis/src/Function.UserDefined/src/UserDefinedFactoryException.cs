using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Function.UserDefined
{
  public class UserDefinedFactoryException : Exception
  {
    public UserDefinedFactoryException(string message, Exception innerException, ICollection<CodeError> errors) : base(message, innerException)
    {
      Errors = errors;
    }

    public ICollection<CodeError> Errors { get; private set; }

    public UserDefinedFactoryException(string message, Exception innerException) : base(message, innerException)
    {
      Errors = EmptyArray<CodeError>.Instance;
    }

    public UserDefinedFactoryException(string message) : base(message)
    {
      Errors = EmptyArray<CodeError>.Instance;
    }

    public UserDefinedFactoryException(string message, ICollection<CodeError> errors) : base(message)
    {
      Errors = errors;
    }
  }
}