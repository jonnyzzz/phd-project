using System.Collections.Generic;

namespace DSIS.UI.Application.Actions
{
  public interface IMenuItem<T> : IUpdateble
  {
    T MainMenu { get; }
    ICollection<IMenuItem<T>> Children { get; }
  }
}