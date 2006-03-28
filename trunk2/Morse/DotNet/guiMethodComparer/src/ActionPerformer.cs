
namespace Eugene.Petrenko.Gui2.MethodComparer
{
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
