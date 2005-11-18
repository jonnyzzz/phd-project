using System;
using System.IO;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.KernelActions.SavePoints
{
    /// <summary>
    /// Summary description for SavePointsKernelAction.
    /// </summary>
    public class SavePointsKernelAction : IAction
    {
        public void SetActionParameters(IParameters parameters)
        {
            if (! (parameters is ISavePointsParameters)) throw new ArgumentException();

            this.parameters = (ISavePointsParameters) parameters;

            string path = this.parameters.FilePath;
            if (!Directory.Exists(Path.GetDirectoryName(path))) throw new ArgumentException("File does not exists");
        }

        private ISavePointsParameters parameters = null;


        public SavePointsKernelAction()
        {
        }

        public void SetProgressBarInfo(IProgressBarInfo pinfo)
        {
        }

        public bool CanDo(IResultSet result)
        {
            ResultSet resultSet = ResultSet.FromResultSet(result);
            IResult[] resultsArray = resultSet.ToResults;
            if (resultsArray.Length != 1) return false;
            foreach (IResult toResult in resultsArray)
            {
                if (!(toResult is IGraphResult)) return false;
            }
            return true;
        }

        public IResultSet Do(IResultSet input)
        {
            if (! CanDo(input)) throw new ArgumentException();
            ResultSet results = ResultSet.FromResultSet(input);
            IResult[] aresults = results.ToResults;
            IGraphResult result = (IGraphResult) aresults[0];

            result.SaveText(parameters.FilePath);

            return ResultSet.Empty().ToResultSet;
        }
    }
}