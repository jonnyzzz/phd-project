using System;
using System.Collections.Generic;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  [JContainerPredefinedComponent]
  public class AttributeScannerImpl : IAttributeScanner
  {
    private readonly JComponentContainerBase myContainer;
    private readonly IAssemblyScaner myScanner;

    public AttributeScannerImpl(JComponentContainerBase container, IAssemblyScaner scanner)
    {
      myContainer = container;
      myScanner = scanner;
    }

    public IEnumerable<Pair<Type, T>> LoadTypes<T>() where T : Attribute
    {
      foreach (var assembly in myContainer.Assemblies)
      {
        foreach (var pair in myScanner.LoadTypes<T>(assembly))
        {
          yield return pair;
        }
      }
    }
  }
}