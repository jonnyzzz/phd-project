using System;

namespace gui.Attributes
{
	/// <summary>
	/// Summary description for InitializeStaticAttrubute.
	/// </summary>
	/// 

	public class InitializeStaticAttrubute : Attribute
	{
        private string register;
        
		public InitializeStaticAttrubute(string register)
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
