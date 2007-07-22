using System.Collections.Generic;
using System.IO;
using System.Xml.Xsl;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilderWithLog<T,Q> : FullImageBuilder<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly string myWorkPath;
    private readonly string myXmlFile;
    private readonly XmlAbstractImageBuilderListener<T, Q> myXmlListener;

    protected FullImageBuilderWithLog(string workPath, long stepLimit, long cellsLimit) : base(stepLimit, cellsLimit)
    {
      myWorkPath = workPath;
      UseUnsimmetric = true;
      
      myXmlFile = Path.Combine(myWorkPath, "log.xml");
      
      myXmlListener = new XmlAbstractImageBuilderListener<T,Q>(myXmlFile);
      
      AddListener(new ConsoleListener<T, Q>());      
      AddListener(myXmlListener);
      
      AddListener(new ComputationPathListener<T,Q>(myWorkPath));

      AddListener(new DrawLastComputationResultListener<T,Q>());
      AddListener(new ComputeEntropyListener<T, Q>());      
      AddListener(new DrawEntropyListener<T,Q>());      
    }

    public void ApplyXSL(IEnumerable<string> xslFiles)
    {
      foreach (string file in xslFiles)
      {
        XslCompiledTransform transform = new XslCompiledTransform(false); 
        transform.Load(file);
        transform.Transform(myXmlFile, myXmlFile + Path.GetFileNameWithoutExtension(file) + ".html");
      }
    }
  }
}