using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  [ComponentImplementation]
  public class ForkJoinImageEntropyBuilderPolicy : IImageEntropyBuilderPolicy
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    public bool Accept(EntropyBuildParameters data)
    {
      return data is ForkJoinImageEntropyParameters;
    }

    public void ComputeMeasure(ImageEntropyData sys, Func<string, Action<IEnumerable<ImageColor>>> saver, Logger logger)
    {
      var pixels = ImageHelpers.ImageToPixels(sys.Image, sys.GraphParameters).ToArray();
      saver("loaded")(pixels);

      var parameters = (ForkJoinImageEntropyParameters)sys.EntropyBuildParameters;
      logger.Write("Start Parallel computations with " + parameters);

      var matrix = new DoubleMatrix();
      var slices = SplitImage(parameters, sys).ToArray();
      logger.Write("Total slices to process: {0}", slices.Count());

      slices
        .AsParallel()
        .ForAll(data =>
          {
            logger.Write("Constructing graph for {0}", data.SliceName);

            var graph = myBuilder.BuildGraphFromImage(data.Data.Image, data.Data.GraphParameters);
            logger.Write("Constructed graph for {2} of {0}, edges {1}", graph.NodesCount, graph.EdgesCount, data.SliceName);
            new ComputeImageMeasureAction(data.Data, logger)
              {
                OnFinalMeasurePixels = result => matrix.AddRange(data.Coord, result)
              }.Apply(graph);

            logger.Write("Entropy completed graph: {0}", data.SliceName);
          });

      logger.Write("Parallel computations completed. ");

      saver("merged")(matrix.Result);
    }

    private IEnumerable<EntropyDataSlice> SplitImage(ForkJoinImageEntropyParameters parameters, ImageEntropyData data)
    {
      var image = data.Image;
      var list = new List<EntropyDataSlice>();

      var sliceX = parameters.SliceX;
      var sliceY = parameters.SliceY;
      
      for(int sX = 0; sX < image.Width; sX += sliceX)
      for(int sY = 0; sY < image.Height; sY += sliceY)
      {
        var bm = new Bitmap(sliceX, sliceY);
        for (int x = sX; x <= sX + sliceX; x++)
        {
          for (int y = sY; y <= sY + sliceY; y++)
          {
            bm.SetPixel(x - sX, y - sY, image.GetPixel(x, y));
          }
        }

        var p = data.CloneData();
        p.Image = bm;
        list.Add(new EntropyDataSlice(new ImagePixel(sX, sY), p));
      }

      return list;
    }

    private struct EntropyDataSlice
    {
      public readonly ImagePixel Coord;
      public readonly ImageEntropyData Data;
      public readonly string SliceName;

      public EntropyDataSlice(ImagePixel c, ImageEntropyData data)
      {
        Coord = c;
        Data = data;
        SliceName = Coord.ToString();
      }
    }

    private class DoubleMatrix
    {
      private readonly Dictionary<ImagePixel, double> myData = new Dictionary<ImagePixel, double>(ImagePixel.XYComparer);

      public void AddRange(ImagePixel offset, IEnumerable<ImageColor> data)
      {
        foreach (var c in data)
        {
          double v;
          var key = new ImagePixel(c.X, c.Y) + offset;

          myData.TryGetValue(key, out v);
          v += c.Color;
          myData[key] = v;          
        }
      }

      public IEnumerable<ImageColor> Result
      {
        get { return myData.Select(k => new ImageColor(k.Key.X, k.Key.Y, k.Value)); }
      }
    }
  }
}