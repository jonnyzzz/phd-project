using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public struct FSData
  {
    private const byte FLAG_IsSelfLoop = 42;

    public bool IsSelfLoop { get; set; }

    public void Load(IInputStream iz)
    {
      byte[] b = new byte[1];
      iz.Read(b, 0, 1);
      IsSelfLoop = b[0] == FLAG_IsSelfLoop;
    }

    public void Save(IOutputStream oz)
    {
      var b = new[] {IsSelfLoop ? FLAG_IsSelfLoop : (byte) 0};
      oz.Write(b, 0, 1);
    }
  }
}