namespace DSIS.CodeCompiler.EqualityFactory
{
  public class EqEqGeneratorEqualityComparer
  {
    public string GeneratePrivateMethods()
    {
      return string.Empty;
    }

    public string AreEqual(string v1, string v2)
    {
      return string.Format("({0} == {1})", v1, v2);
    }
  }
}