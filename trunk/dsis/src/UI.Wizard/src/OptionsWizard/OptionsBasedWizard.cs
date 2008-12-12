using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.Wizard.OptionsWizard
{
  public class OptionsBasedWizard<T,R> : IWizardPack<R>, IWizardPack
  {
    private readonly string myTitle;
    private readonly List<IOptionsBasedFactory<T, R>> myFactory;
    private readonly ListSelectorWizardPage<IOptionsBasedFactory<T, R>> myFactorySelector;
    private readonly Dictionary<IOptionsBasedFactory<T, R>, Pair<IWizardPage, T>> myOptionsCache 
      = new Dictionary<IOptionsBasedFactory<T, R>, Pair<IWizardPage, T>>();
    private T myOptions;
    private bool myIsFinished;
    private bool myIsCanceled;

    public OptionsBasedWizard(string title, IListSelectorFactory listFactory, IEnumerable<IOptionsBasedFactory<T, R>> factories, Func<IOptionsBasedFactory<T, R>, bool> enabled)
    {
      myTitle = title;
      myFactory = new List<IOptionsBasedFactory<T, R>>(factories);
      myFactory.Sort((x,y)=>x.FactoryTitle.CompareTo(y.FactoryTitle));

      myFactorySelector = new ListSelectorWizardPage<IOptionsBasedFactory<T, R>>(
        listFactory, 
        factories,
        x => x.FactoryTitle, 
        enabled);
    }

    [Autowire]
    private IFormGeneratorWizardPageFactory FormGeneratorFactory { get; set; }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public R GetResult()
    {
      if (!myIsFinished)
        throw new Exception("Failed to get result for non-finished wizard");

      if (myIsCanceled)
        throw new Exception("Failed to get result for canceled wizard");

      return myFactorySelector.SelectedItem.CreateFactory(myOptions);
    }

    public string Title 
    { 
      get { return myTitle; }
    }

    public IWizardPage FirstPage
    {
      get { return myFactorySelector; }
    }

    public bool IsLastPage(IWizardPage page)
    {
      return page != myFactory;
    }

    public IWizardPage Next(IWizardPage page)
    {
      if (page != myFactorySelector)
        return null;
      
      var optz = CreateOptions();
      myOptions = optz.Second;
      return optz.First;
    }

    private Pair<IWizardPage, T> CreateOptions()
    {
      var factory = myFactorySelector.SelectedItem;

      Pair<IWizardPage, T> iu;
      if (myOptionsCache.TryGetValue(factory, out iu))
        return iu;

      var obj = factory.CreateOptions();
      return new Pair<IWizardPage, T>(FormGeneratorFactory.CreatePage(factory.OptionsTitle, obj), obj);
    }

    public void OnFinish()
    {
      myIsFinished = true;
    }

    public void OnCancel()
    {
      myIsCanceled = true;
    }

    public void PageShown(IWizardPage page)
    {
      if (page == FirstPage)
        myOptions = default(T);
    }
  }
}
