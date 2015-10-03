using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
  public interface IDefinedAction
  {
    string Name { get; }
    IAction Action { get; }
    IParameters GetParameters(ResultSet forSet);
  }
  
 
 public interface IUnsimmetricDefinedAction : IDefinedAction
 {
   bool UseUnsimmetric {get; set; }
   int UnsimmetricStep {get; set; }
   int UnsimmetrisSteps {get; }  
 }
}