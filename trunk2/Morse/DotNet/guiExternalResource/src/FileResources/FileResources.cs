using System;
using System.Collections;
using System.IO;
using guiExternalResource.src.xml;

namespace guiExternalResource.src.FileResources
{
	/// <summary>
	/// Summary description for FileResources.
	/// </summary>
	public class FileResources
	{
		Hashtable fileMappings = new Hashtable(); //string -> string
		public FileResources()
		{
		}

		public void RegisterFile(string file, string path)
		{
			if (fileMappings.ContainsKey(file)) throw new DataException("Dublicating key");
			fileMappings[file] = path;
		}

		public string this[ string resource] {
			get
			{
				string file = fileMappings[resource] as string;
				if (file == null ) throw new DataException("File resource was not registered");
				if (!File.Exists(file)) throw new DataException("File resource was not found");
				return file;
			}
		}
	}
}
