using System;
using DSIS.Utils.Bean;

namespace DSIS.Scheme.Objects.Systemx
{
  public interface IOptionsHolder
  {
    /// <summary>
    /// Object providing options to create the system.
    /// Null is the place for no options.
    /// New instance of that object will be created for UI
    /// Values will be filled according to <see cref="IncludeGenerateAttribute"/>
    /// field markers
    /// </summary>
    Type OptionsObjectType { get; }
  }
}