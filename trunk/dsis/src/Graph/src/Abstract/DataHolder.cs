using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class DataHolder : IDataHolder {
    private object myData;

    public bool HasData<T>()
    {
      return myData is T;
    }

    public void SetData<T>(T data)
    {
      myData = data;
    }

    public T GetData<T>(Lazy<T> def)
    {
      if (myData is T)
        return (T)myData;

      var newValue = def();
      myData = newValue;
      return newValue; 
    }
  }
}