using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;
using MorseKernel2;

namespace gui2.Document
{
	/// <summary>
	/// Summary description for Function.
	/// </summary>
	[Serializable]
	public class Function
	{
		public Function(string[] equations)
		{
			this.equations = equations;	
			
			string equation = "";
			foreach (string eq in equations)
			{
				equation += eq + "\n";
			}

			this.function = createFunction(equation);
		}

		private IFunction createFunction(string equations)
		{
			IWritableFunction writableFunction = new CFunctionImplClass();
			try 
			{
				writableFunction.SetEquations(equations);
			} catch (Exception)
			{
				throw new FunctionExceptions(writableFunction.GetLastError());
			}

			return (IFunction)writableFunction;
		}

		private string[] equations;
		private IFunction function;

		public string[] Equations
		{
			get { return equations; }
		}

		public IFunction IFunction
		{
			get
			{
				return function;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("Function Object\n[");
			foreach (string equation in equations)
			{
				builder.Append(equation);
				builder.Append("\n");
			}
			builder.Append("\n]");
			return builder.ToString();
		}

	}
}
