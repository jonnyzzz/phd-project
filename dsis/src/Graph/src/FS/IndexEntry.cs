namespace DSIS.Graph.FS
{
  public struct IndexEntry
  {
    public long EntryId { get; set; }
    public long Begin { get; set; }
    public long Data { get; set; }

    public override string ToString()
    {
      return string.Format("IndexEntry{{Id : {2}, Begin: {0}, Data: {1}}}", Begin, Data, EntryId);
    }
  }
}