using System;
using System.Drawing;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Controls.Control;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Parameters
{
  public delegate void ParametersSubmitted(IParameters parameters);

  public class ParametersControl : UserControl, ISubmittable
  {
    //pseudo abstract method
    protected virtual IParameters SubmitDataInternal()
    {
      throw new NotImplementedException("Implement SubmitData in the inheritor class");
    }

    //abstract
    public virtual string BoxCaption
    {
      get { throw new NotImplementedException("Implement ParametersCaption in the inheritor class"); }
    }

    public virtual bool NeedShowForm
    {
      get { return true; }
    }

    private IParameters cachedParameters = null;

    private void InitializeComponent()
    {
      // 
      // ParametersControl
      // 
      Name = "ParametersControl";
      Size = new Size(360, 288);
    }

    public IParameters CachedParameters
    {
      get { return cachedParameters; }
    }

    public void SubmitData()
    {
      try
      {
        cachedParameters = SubmitDataInternal();
        if (DataSubmitted != null)
        {
          DataSubmitted(CachedParameters);
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public event ParametersSubmitted DataSubmitted;
  }
}