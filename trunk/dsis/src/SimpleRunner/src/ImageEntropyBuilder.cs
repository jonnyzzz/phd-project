using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DSIS.Graph.Images;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  [ComponentImplementation]
  public class ImageEntropyBuilder : ImageEntropyBuilderBase
  {
    private IEnumerable<string> ListImages()
    {
      yield return @"E:\work\dsis\dsis\img\pic_36_crop.png";
/*
      foreach (var file in Directory.GetFiles(@"E:\work\dsis\dsis\img", "*.png"))
      {
        yield return file;
      }
*/
    } 
    protected override IEnumerable<IEnumerable<ImageEntropyData>> GetSystemsToRun2()
    {
      yield return ListImages()
        .Select(file => new ImageEntropyData
                          {
                            Name = Path.GetFileNameWithoutExtension(file),
                            Image = new Bitmap(Image.FromFile(file)),
                            GraphParameters = new FullGraphFromImageBuilderParameters
                                                {
                                                  NumberOfNeighboursPerAxis = 1,
                                                  Hash = c => c.R/32,
                                                }
                          })
        .ToArray();
/*
      yield return Directory.GetFiles(@"E:\work\dsis\dsis\img", "*.png")
        .Select(file => new ImageEntropyData
                          {
                            Name = Path.GetFileNameWithoutExtension(file),
                            Image = new Bitmap(Image.FromFile(file)),
                            GraphParameters = new ComplexGraphFromImageBuilderParameters()
                                                {
                                                  NumberOfNeighboursPerAxis = 4,
                                                  NumberOfEdgesPerPixel = 8,
                                                  Hash = c => c.R/32,
                                                  Threasold = 120/32
                                                }
                          })
        .ToArray();
*/

/*
      yield return new[]
                     {
                       new ImageEntropyData
                         {
                           Name = "pic_52",
                           Image = new Bitmap(Image.FromFile(@"E:\work\dsis\dsis\img\pic_52_down.png")),
                           GraphParameters = new GraphFromImageBuilderParameters
                                               {
                                                 NumberOfNeighboursPerAxis = 2,
                                                 NumberOfEdgesPerPixel = 2,
                                                 Hash = c => c.R/32,
                                                 Threasold = 120/32
                                               }
                         },
                         
                         new ImageEntropyData
                         {
                           Name = "pic_39",
                           Image = new Bitmap(Image.FromFile(@"E:\work\dsis\dsis\img\pic_39_down.png")),
                           GraphParameters = new GraphFromImageBuilderParameters
                                               {
                                                 NumberOfNeighboursPerAxis = 2,
                                                 NumberOfEdgesPerPixel = 2,
                                                 Hash = c => c.R/32,
                                                 Threasold = 10
                                               }
                         },
                     };      
*/
    }    
  }
}