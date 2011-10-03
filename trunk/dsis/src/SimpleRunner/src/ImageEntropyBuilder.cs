using System.Collections.Generic;
using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  [ComponentImplementation]
  public class ImageEntropyBuilder : ImageEntropyBuilderBase
  {
    protected override IEnumerable<IEnumerable<ImageEntropyData>> GetSystemsToRun2()
    {
      yield return new[]
                     {
//                       new ImageEntropyData
//                         {
//                           Name = "pic_52",
//                           Image = new Bitmap(Image.FromFile(@"E:\work\dsis\dsis\img\pic_52_down.png")),
//                           GraphParameters = new GraphFromImageBuilderParameters
//                                               {
//                                                 NumberOfNeighboursPerAxis = 2,
//                                                 NumberOfEdgesPerPixel = 2,
//                                                 Hash = c => c.R/32,
//                                                 Threasold = 120/32
//                                               }
//                         },
                         
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
    }    
  }
}