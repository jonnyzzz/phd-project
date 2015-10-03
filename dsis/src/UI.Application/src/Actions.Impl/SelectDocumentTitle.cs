using System;
using DSIS.Core.Ioc;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.Utils.Bean;

namespace DSIS.UI.Application.Actions.Impl
{
  [TypeInstanciable]
  public class SelectDocumentTitle : SimpleWizard, IWizardPack<string>
  {
    private readonly DocumentTitle myTitle;

    public SelectDocumentTitle(IFormGeneratorWizardPageFactory factory, DocumentTitle title) : base(new[] {factory.CreatePage("", title)})
    {
      myTitle = title;
      Title = "Select Document Title";
    }

    [Serializable]
    public class DocumentTitle
    {
      [IncludeGenerate(Title = "Select title of the defined system")]
      public string Title { get; set; }
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public string GetResult()
    {
      return myTitle.Title;
    }

    public void Dispose()
    {
      //TODO:
    }
  }
}