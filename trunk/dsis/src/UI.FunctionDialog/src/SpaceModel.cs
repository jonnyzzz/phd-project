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

    public SpaceModel()
    {
      Dimension = 1;
    }

    public int Dimension
    {
      get { return myDimension; }
      set
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