using System;
using System.IO;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for ResourceLoader.
	/// </summary>
	public class ResourceLoader
	{       
        public static string LoadResourceAsText(string name)
        {
            TextReader tr = File.OpenText(name);
            string data = tr.ReadToEnd();
            tr.Close();
            return data;
        }
	}
}
