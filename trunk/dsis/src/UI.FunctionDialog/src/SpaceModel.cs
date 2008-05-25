using System;
using System.Collections.Generic;

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
  }
}