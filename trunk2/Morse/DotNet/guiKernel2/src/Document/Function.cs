using System;
using System.Text;
using MorseKernel2;

namespace guiKernel2.Document
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
				builder.Append("\t");
				builder.Append(equation);
				builder.Append("\n");
			}
			builder.Append("]\n");
			return builder.ToString();
		}


		public static Function CreateTestFunction()
		{
			return new Function( new string[] {
												  "_dimension=1;",
												  "y1 = x1;",
												  "y2 = x2;",
				 								  "space_min1 = 0;",
												  "space_min2 = 0;",				  
												  "space_max1 = 1;",
												  "space_max1 = 1;",
												  "iterations = 1;",
												  "grid1 = 10;",
												  "grid2 = 10;"
				});
		}


	}
}
