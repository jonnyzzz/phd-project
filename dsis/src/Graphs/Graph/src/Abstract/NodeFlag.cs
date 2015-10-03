using System;

namespace DSIS.Graph.Abstract
{
  public class NodeFlag : IDisposable   
  {
    public readonly uint Flag;
    private readonly string myName;
    private readonly NodeFlags myHolder;

    internal NodeFlag(uint flag, string name, NodeFlags holder, bool reuse)
    {
      Flag = flag;
      myHolder = holder;
      myName = name;
      IsReusing = reuse;
    }

    public bool IsReusing { get; private set; }

    public string Name
    {
      get { return myName; }
    }

    public override string ToString()
    {
      return "NodeFag: " + myName;
    }

    internal NodeFlags Holder
    {
      get { return myHolder; }
    }

    public void Dispose()
    {
      myHolder.RemoveFlag(this);
    }
  }
}