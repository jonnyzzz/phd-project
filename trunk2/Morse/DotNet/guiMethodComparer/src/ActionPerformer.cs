using System.IO;
using System.Xml;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	public class ActionPerformer
	{	
        private ResultDumpCollector col;
    
	    public ActionPerformer(IAttachableSimpleWriter logFile, XmlDocument task )
	    {
            col = new ResultDumpCollector(logFile, task);
	    }

        public void Perform(IteratingAction[] actions, string path)
        {
            foreach (IteratingAction action in actions)
                Perform(action);
			path = Path.Combine(path, "log.xml");
			col.SaveXMLLog(path);
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
