using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.SimpleRunner.ImageEntropy.ForkJoin;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy
{
  [ComponentImplementation]
  public class ImageEntropyBuilder : ImageEntropyBuilderBase
  {
    private IEnumerable<string> ListImages()
    {
      return new[]{@"E:\DSIS\DSIS\img", @"E:\work\DSIS\dsis\img\"}
        .Where(Directory.Exists)
        .SelectMany(d => Directory.GetFiles(d, "*.png"))
        .Where(x=> new[]
          {
            "28",
            "38_up", "38_do", 
            "40_up", 
            "43_up"
          }.Any(x.Contains));
    }

    protected override IEnumerable<IEnumerable<ImageEntropyData>> GetSystemsToRun2()
    {
/*
      yield return (
                     new[]
                       {
//                         new {Name = "Cross-20x20x2", Image = WellknownTestImages.Cross(20, 2)}, 
//                         new {Name = "HLines-20x20x2", Image = WellknownTestImages.HLines2(20, 20, 2)},
//                         new {Name = "HVLines-20x20x2", Image = WellknownTestImages.HVLines2(20, 20, 2)}, 
                         new {Name = "Serpinsky-3", Image = new Bitmap(Image.FromFile(@"E:\work\dsis\dsis\img\pic_serpinsky_3.png"))}
                       })                   
        .Select(file => new ImageEntropyData
                          {
                            ExecutionTimeout = TimeSpan.FromMinutes(30),
                            Name = file.Name,
                            Image = file.Image,
                            MeasureIterations = 50*1000,
                            MeasureTimeout = TimeSpan.FromMinutes(10),
                            MeasurePrecision = 1e-18,

                            RenderMinColor = Color.Black,
                            RenderMaxColor = Color.White,

                            GraphParameters = new FullGraphFromImageBuilderParameters
                                                {
                                                  NumberOfNeighboursPerAxis = 1,
                                                  Hash = c => c.R,
                                                }
                          }).ToArray();
*/
      Func<string, EntropyBuildParameters, ImageEntropyData> basicData
        = (file, entropy) => new ImageEntropyData
                               {
                                 ExecutionTimeout = TimeSpan.FromMinutes(10),
                                 Name = Path.GetFileNameWithoutExtension(file),
                                 Image = new Bitmap(Image.FromFile(file)),

                                 MeasureIterations = 1500,
                                 MeasureTimeout = TimeSpan.FromMinutes(10),
                                 MeasurePrecision = 1e-6,

                                 RenderMinColor = Color.Black,
                                 RenderMaxColor = Color.White,

                                 EntropyBuildParameters = entropy,
                                 GraphParameters = new FullGraphFromImageBuilderParameters
                                                     {
                                                       NumberOfNeighboursPerAxis = 1,
                                                       Hash = c => c.R,
                                                     }
                               };

/*
      yield return ListImages()
        .Select(file => basicData(file, new SimpleEntropyBuildParameters())).ToArray();
*/

      yield return ListImages()
        .Select(file => basicData(file, new ForkJoinImageEntropyParameters
                                          {
                                            SliceX = 20,
                                            SliceY = 20,
                                            Overlap = 1
                                          })).ToArray();

      yield return ListImages()
        .Select(file => basicData(file, new ForkJoinImageEntropyParameters
                                          {
                                            SliceX = 20,
                                            SliceY = 20,
                                            Overlap = 5
                                          })).ToArray();

      yield return ListImages()
        .Select(file => basicData(file, new ForkJoinImageEntropyParameters
                                          {
                                            SliceX = 20,
                                            SliceY = 20,
                                            Overlap = 0
                                          })).ToArray();
      /*
      yield return ListImages()
        .Select(file => new ImageEntropyData
                          {
                            ExecutionTimeout = TimeSpan.FromMinutes(30),
                            Name = Path.GetFileNameWithoutExtension(file),
                            Image = new Bitmap(Image.FromFile(file)),
                            MeasureIterations = 1500,
                            MeasureTimeout = TimeSpan.FromMinutes(10),
                            MeasurePrecision = 1e-3,

                            RenderMinColor = Color.Black,
                            RenderMaxColor = Color.White,
                            EntropyBuildParameters = new SimpleEntropyBuildParameters(),
                            GraphParameters = new FullGraphFromImageBuilderParameters
                            {
                              NumberOfNeighboursPerAxis = 1,
                              Hash = c => c.R,
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