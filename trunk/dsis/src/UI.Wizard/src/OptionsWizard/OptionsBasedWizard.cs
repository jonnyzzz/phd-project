using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.Wizard.OptionsWizard
{
  /// <summary>
  /// Inherit from that class in order to create your own OptionsBased wizard.
  /// This class can only be instantiated from JContainer
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="R"></typeparam>
  /// <typeparam name="F"></typeparam>
  public abstract class OptionsBasedWizard<T,R,F> : IWizardPack<R>, IWizardPack
    where F : class, IOptionsBasedFactory<T,R>
  {
    private readonly string myTitle;   
    private readonly List<F> myFactories;
    private readonly IListSelectorWizardPage<F> myFactorySelector;
    private T myOptions;
    private bool myIsFinished;
    private bool myIsCanceled;

    protected OptionsBasedWizard(string title, IListSelectorWizardPageFactory listFactory, IEnumerable<F> factories, Func<F, bool> enabled)
    {
      myTitle = title;
      myFactories = new List<F>(factories);
      myFactories.Sort(Comparer);

      myFactorySelector = listFactory.Create(myFactories, x=>GetFactoryName(x), enabled);
    }

    /// <summary>
    /// NOTE: Is called from constructor
    /// </summary>
    protected virtual ItemDescr GetFactoryName(F factory)
    {
      return new ItemDescr(factory.FactoryName);
    }

    /// <summary>
    /// NOTE: Is called from Constructor!
    /// </summary>
    protected virtual Comparison<F> Comparer
    {
      get { return (x, y) => GetFactoryName(x).Title.CompareTo(GetFactoryName(y).Title); }
    }

    [Autowire]
    private IFormGeneratorWizardPageFactory myFormGeneratorFactory { get; set; }

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

      return myFactorySelector.SelectedItem.Create(myOptions);
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
      return page != FirstPage;
    }

    public IWizardPage Next(IWizardPage page)
    {
      if (page != FirstPage)
        return null;
      
      var optz = CreateOptions();
      myOptions = optz.Second;
      return optz.First;
    }

    public Ref<string> ValidateLazy(IWizardPage page)
    {
      //TODO!
      return Ref.Null<string>();
    }

    private Pair<IWizardPage, T> CreateOptions()
    {
      var factory = myFactorySelector.SelectedItem;
      var obj = factory.CreateOptions();
      return new Pair<IWizardPage, T>(myFormGeneratorFactory.CreatePage(GetOptionsTitle(factory), obj), obj);
    }

    protected virtual string GetOptionsTitle(F opts)
    {
      return opts.FactoryName + " options";
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

    public void Dispose()
    {
      //TODO:
    }
  }
}
