using System;
using System.Collections;
using System.IO;
using guiExternalResource.Core;

namespace guiExternalResource.src.FileResources
{
	/// <summary>
	/// Summary description for TempFileAllocator.
	/// </summary>
	public class TempFileAllocator : IDisposable
	{
		private ArrayList files = new ArrayList();

		public TempFileAllocator()
		{			
		}

		public void Dispose()
		{
			foreach (string file in files)
			{
				try
				{
					File.Delete(file);
				} catch (Exception) {}
			}
		}

		private static int num = 0;

		public string CreateFile()
		{
			string file = string.Format("{7}/{0}.{1}.{2}-{3}.{4}.{5}.{6}.{8}.temp", 
				DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, 
				DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, 
			                            ResourceManager.Instance.TemporaryPath, num++);

			while(File.Exists(file)) file += "_";
			files.Add(file);
			
			return ResourceManager.Instance.SimplyfyPath(file);
		}

		public string SaveToTempFile(string data)
		{
			string file = CreateFile();
			TextWriter writer = File.CreateText(file);
			writer.WriteLine(data);
			writer.Close();
			return file;
		}
	}
}
