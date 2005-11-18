using System.Collections;
using EugenePetrenko.Gui2.ExternalResource.Xml;

namespace EugenePetrenko.Gui2.ExternalResource.Strings
{
    /// <summary>
    /// Summary description for StringSet.
    /// </summary>
    public class StringSet
    {
        private Hashtable strings = new Hashtable();

        public StringSet()
        {
        }

        public void AddString(string key, string value)
        {
            if (strings.ContainsKey(key)) throw new DataException("Key duplications");
            strings[key] = value;
        }


        public string this[string key]
        {
            get { return strings[key] as string; }
        }
    }
}