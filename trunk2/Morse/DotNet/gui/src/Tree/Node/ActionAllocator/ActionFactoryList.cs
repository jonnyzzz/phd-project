using System;
using System.Collections;
using gui.Logger;

namespace gui.src.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for ActionFactoryList.
	/// </summary>
	public class ActionFactoryList : IEnumerable
	{
        private ArrayList list;
		public ActionFactoryList()
		{
            this.list = new ArrayList();
		}

        public void AddActionList(IActionFactory factory)
        {
            foreach (IActionFactory actionFactory in list)
            {
                if (ActionFactoryEquals(actionFactory, factory)) return;
            }
            Log.LogMessage("Action {0} was registered", factory.GetType().Name);
            list.Add(factory);
        }

        public void RemoveAction(IActionFactory factory)
        {
            foreach (IActionFactory actionFactory in list)
            {
                if (ActionFactoryEquals(actionFactory, factory))
                { 
                    //todo: possible will not works as desired
                    list.Remove(actionFactory);
                }
            }
        }

        private bool ActionFactoryEquals(IActionFactory af1, IActionFactory af2)
        {
            return Object.ReferenceEquals(af1, af2);
        }

        public void RemoveAll()
        {
            list.Clear();
        }


        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {            
            return list.GetEnumerator();
        }
        #endregion
    }
}
