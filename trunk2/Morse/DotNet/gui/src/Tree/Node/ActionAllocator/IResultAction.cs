using System;

namespace gui.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for IComputationAction.
	/// </summary>
	public abstract class IResultAction
	{
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

        protected IResultAction( string text)
        {
            this.text = text;
        }

        protected IResultAction() : this("")
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



        public abstract void DoAction();
	}
}
