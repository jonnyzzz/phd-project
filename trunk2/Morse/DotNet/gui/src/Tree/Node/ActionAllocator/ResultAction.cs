using System;

namespace gui.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for IComputationAction.
	/// </summary>
	public abstract class ResultAction
	{
        #region features
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        protected ResultAction( string text)
        {
            this.text = text;
        }

        protected ResultAction() : this("")
        {            
        }

        public bool isSelected
        {
            get
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Text;
        }
        #endregion

        public abstract void DoAction();
	}
}
