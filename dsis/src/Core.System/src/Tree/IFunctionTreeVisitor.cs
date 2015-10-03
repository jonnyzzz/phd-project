/*
 * Created by: Eugene Petrenko 
 * Created: 18 ������ 2006 �.
 */


namespace DSIS.Core.System.Tree
{
  public interface IFunctionTreeVisitor<T>
  {
    T AcceptFunctionNode(IFunctionNode node, T t);
  }
}