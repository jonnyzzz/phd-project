namespace EugenePetrenko.Gui2.Application.TreeNodes.MenuItems
{
    /// <summary>
    /// Summary description for DelegatedMenuItem.
    /// </summary>
    /// 
    public delegate void Click();

    public class DelegatedMenuItem : TreeMenuItem
    {
        private readonly Click click;

        public DelegatedMenuItem(string caption, Click click) : base(caption)
        {
            this.click = click;
        }

        protected override void EventClick()
        {
            click();
        }
    }
}