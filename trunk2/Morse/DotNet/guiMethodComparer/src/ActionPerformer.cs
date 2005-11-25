using System;
using System.IO;
using System.Text;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for ActionPerformer.
	/// </summary>
	public class ActionPerformer
	{	
        private ResultDumpCollector col;
    
	    public ActionPerformer(IAttachableSimpleWriter logFile )
	    {
            col = new ResultDumpCollector(logFile);
	    }

        public void Perform(IteratingAction[] actions)
        {
            foreach (IteratingAction action in actions)
            {
                Perform(action);
            }
        }

        protected void Perform(IteratingAction action)
        {
            using(ResultDumper dmp = col.CreateDumper(action.Name)) 
            {
                action.Compute(dmp);
            }
        }

	}
}
