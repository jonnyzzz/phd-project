using System;
using gui.Logger;
using MorseKernelATL;

namespace gui.Tree.Serialization
{
	/// <summary>
	/// Summary description for KernelNodeSerializer.
	/// </summary>
	public class KernelNodeSerializer
	{
		public static void SerializeKernelNode(string filename, IKernelNode node)
		{
			Log.LogMessage(typeof(KernelNodeSerializer), "filename = ", filename);

			ISerializer serializer = new CSerializerClass();
			serializer.SaveKernelNode(new SerializerOutput(filename), node);
		}

		public static IKernelNode DeSerializeKernelNode(string filename)
		{
			ISerializer serializer = new CSerializerClass();
			return serializer.LoadKernelNode(new SerializerInput(filename), Runner.Kernel);
		}


		private class SerializerInput : ISerializerInputData
		{
			private string filename;

			public SerializerInput(string filename)
			{
				this.filename = filename;
			}

			public string FileName()
			{
				return filename;
			}
		}

		private class SerializerOutput : ISerializerOutputData
		{
			private string filename;

			public SerializerOutput(string filename)
			{
				this.filename = filename;
			}

			public string FileName()
			{
				return filename;
			}
		}

	}
}
