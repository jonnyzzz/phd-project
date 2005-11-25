using System;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	public interface ISimpleWriter
    {
        void WriteLine(string format, params object[] data);        
    }
	
	public interface IAttachableSimpleWriter : ISimpleWriter
	{
	    void AddHandler(ISimpleWriter wr);
	    void RemoveHandler(ISimpleWriter wr);
	    
	    void WriteBuildCommand(string format, params object[] data);
	}
}
