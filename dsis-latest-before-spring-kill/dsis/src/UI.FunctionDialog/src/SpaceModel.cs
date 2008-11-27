using System;
using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Core.System.Impl;

namespace DSIS.UI.FunctionDialog
{
  public class SpaceModel
  {
    private readonly List<SpaceParametersRowModel> mySpaces = new List<SpaceParametersRowModel>();
    private int myDimension;

    public event EventHandler<EventArgs> OnModelChanged;
    
    public ICollection<SpaceParametersRowModel> Spaces
    {
      get { return mySpaces.AsReadOnly(); }
    }

    public SpaceModel() :this(1)
    {
    }

    public SpaceModel(int dimension)
    {
      UpdateDimension(dimension);
    }

    public virtual bool CanChangeDimension
    {
      get { return true; }
    }

    public virtual int Dimension
    {
      get { return myDimension; }
      set { UpdateDimension(value); }
    }

    private void UpdateDimension(int value)
    {
      myDimension = value;
      while (mySpaces.Count < myDimension)
      {
        var item = new SpaceParametersRowModel();
        mySpaces.Add(item);
      }

      while (mySpaces.Count > myDimension)
      {
        mySpaces.RemoveAt(mySpaces.Count - 1);
      }

      FireModelChanged();
    }

    private void FireModelChanged()
    {
      if (OnModelChanged != null)
      {
        OnModelChanged(this, EventArgs.Empty);
      }
    }   
    
    public ISystemSpace Create()
    {
      var grid = new long[Dimension];
      var left = new double[Dimension];
      var right = new double[Dimension];

      for(int i=0; i<Dimension; i++)
      {
        var row = mySpaces[i];
        grid[i] = row.Grid;
        left[i] = row.Left;
        right[i] = row.Right;
      }

      return new DefaultSystemSpace(Dimension, left, right, grid);
    }
  }
}