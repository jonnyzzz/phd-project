using System;
using MorseKernel2;

namespace guiKernel2.src.Document
{
	/// <summary>
	/// Summary description for Document.
	/// </summary>
	public class Document
	{
		private IKernell kernell;

		public Document(IFunction function)
		{
			IWritableKernell writableKernell = new CKernellImplClass();
			writableKernell.SetFunction(function);
			
			kernell = (IKernell)writableKernell;
		}

		public IKernell Kernell
		{
			get
			{
				return kernell;
			}
		}
	}
}
