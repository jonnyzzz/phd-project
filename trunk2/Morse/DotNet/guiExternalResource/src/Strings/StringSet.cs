using System;
using System.Collections;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.ExternalResource.Xml;

namespace EugenePetrenko.Gui2.ExternalResource.Strings
{
    /// <summary>
    /// Summary description for StringSet.
    /// </summary>
    public class StringSet : IStringResources
    {
        private Hashtable strings = new Hashtable();

        public StringSet()
        {
        }

        public void AddString(string key, string value)
        {
            if (strings.ContainsKey(key.ToLower())) 
				throw new DataException("Key duplications");
            strings[key.ToLower()] = value;
        }


        public string this[string key]
        {
            get { return strings[key.ToLower()] as string; }
        }

		#region IStringResources
    	public string CellDivision
    	{
    		get { return this["CellDivisor"]; }
    	}

    	public string AdaptivePrecision
    	{
    		get { return this["AdaptivePrecision"]; }
    	}

    	public string AdaptiveUpperLimit
    	{
			get { return this["AdaptiveUpperLimit"]; }
		}

    	public string PointsInCell
    	{
			get { return this["PointsInCell"]; }
		}

    	public string PointLeftOffset
    	{
			get { return this["PointLeftOffset"]; }
		}

    	public string PointRightOffset
    	{
			get { return this["PointRightOffset"]; }
		}

    	#endregion
    }
}