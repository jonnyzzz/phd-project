using System;

namespace DSIS.Scheme
{
  public interface INode
  {
    void Init(IWriteableContext context);
    void Compute(IWriteableContext context);
    void Dispose(IWriteableContext context);    
  }

  //resulted if Init is unable to work under the current context
  public class ContextMissmatchException : Exception
  {    
  }
}