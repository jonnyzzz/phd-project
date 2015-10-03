using DSIS.Core.System;

namespace DSIS.Scheme.Objects.Systemx
{
  public interface IContiniousFunctionSolverFactory : IOptionsHolder
  {
    string MethodName { get; }

    IContiniousSolverParameters CreateOptions();

    /// <summary>
    /// Creates instance of ISystemInfo using parameters specified 
    /// in object of type <see cref="IOptionsHolder.OptionsObjectType"/>
    /// </summary>
    /// <param name="system">System to integrate</param>
    /// <param name="parameters">parameters to the system. 
    /// Must be an instance of <see cref="IOptionsHolder.OptionsObjectType"/></param>
    /// <returns>new system info</returns>
    ISystemInfo Create(ISystemInfo system, IContiniousSolverParameters parameters);
  }
}