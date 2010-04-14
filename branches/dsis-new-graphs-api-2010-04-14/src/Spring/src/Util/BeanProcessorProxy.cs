using DSIS.Spring.Attributes;

namespace DSIS.Spring.Util
{
  [SpringBean]
  public class BeanProcessorProxy
  {
    private readonly BeanProcessor myProc;

    public BeanProcessorProxy(BeanProcessor proc)
    {
      myProc = proc;
    }

    public object PostProcessBeforeInitialization(object instance, string name)
    {
      return myProc.PostProcessBeforeInitialization(instance, name);
    }

    public object PostProcessAfterInitialization(object instance, string objectName)
    {
      return myProc.PostProcessAfterInitialization(instance, objectName);
    }

    public void AfterPropertiesSet()
    {
      myProc.AfterPropertiesSet();
    }
  }
}