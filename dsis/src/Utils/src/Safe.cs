using System;
using log4net;

namespace DSIS.Utils
{
  public class NoSafe : ISafe
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (NoSafe));

    public static readonly ISafe Instance = new NoSafe();

    public void Safe(VoidDelegate action)
    {
      try
      {
        action();
      } catch(Exception e)
      {
        LOG.Error(e);
      }
    }

    public void SafeIgnore(VoidDelegate action)
    {
      try
      {
        action();
      } catch(Exception e)
      {
        LOG.Error(e);
      }
    }

    public void Safe<T>(T obj, DAction<T> action)
    {
      try
      {
        action(obj);
      } catch (Exception e)
      {
        LOG.Error(e);
      }
    }

    public void SafeIgnore<T>(T obj, DAction<T> action)
    {
      try
      {
        action(obj);
      } catch (Exception e)
      {
        LOG.Error(e);
      }
    }

    public T Safe<T>(TDelegate<T> del, T def)
    {
      try
      {
        return del();
      } catch (Exception e)
      {
        LOG.Error(e);
      }
      return def;
    }
  }
}