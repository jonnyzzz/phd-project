using System;

namespace gui.Attributes
{
	/// <summary>
	/// Summary description for InitializeStaticAttrubute.
	/// </summary>
	/// 

	public class InitializeStaticAttrubute : Attribute
	{
        public enum Type : short
        {
            TreeNodeAction
        };      
        private string register;
        
		public InitializeStaticAttrubute(Type type, string register)
		{            
            this.register = register;
		}

        public string Register
        {
            get
            {
                return register;
            }
        }
	}
}
