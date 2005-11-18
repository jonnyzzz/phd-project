using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Actions
{
    public delegate void ProgressBarTick();

    public delegate void ProgressBarFinish();

    public delegate void ProgressBarNewLength(int length);

    public delegate void ProgressBarNewTask(string caption);

    public class ProgressBarInfo
    {
        public event ProgressBarTick Tick;
        public event ProgressBarNewTask NewTask;
        public event ProgressBarFinish TaskFinish;
        public event ProgressBarNewLength NewLength;

        public IProgressBarInfo GetProgressBarInfo(ActionWrapper actionWrapper)
        {
            if (NewTask != null)
            {
                NewTask(actionWrapper.ActionName);
            }

            ProgressBarInfoImpl info = new ProgressBarInfoImpl(this);
            if (NewLength != null)
            {
                NewLength(info.Length());
            }
            return info;
        }

        private class ProgressBarInfoImpl : IProgressBarInfo
        {
            private ProgressBarInfo instance;

            public ProgressBarInfoImpl(ProgressBarInfo instance)
            {
                this.instance = instance;
            }

            public void Finish()
            {
                if (instance.TaskFinish != null)
                {
                    instance.TaskFinish();
                }
            }

            public int Length()
            {
                return 300;
            }

            public void Next()
            {
                if (instance.Tick != null)
                {
                    instance.Tick();
                }
            }

            public bool NeedStop()
            {
                return false;
            }

            public void Start()
            {
                if (instance.Tick != null)
                {
                    instance.Tick();
                }
            }
        }
    }
}