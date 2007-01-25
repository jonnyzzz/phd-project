/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */


namespace DSIS.Core.System.Tree
{
  public interface IFunctionTreeVisitor<T>
  {
    T AcceptFunctionNode(IFunctionNode node, T t);    
  }
}