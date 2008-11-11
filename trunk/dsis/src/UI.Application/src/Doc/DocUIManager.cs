using System;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation(Startable = true)]
  public class DocUIManager : IDisposable
  {
    private readonly IApplicationClass myApp;
    private readonly IMainForm myMainForm;
    private readonly IComponentContainer myRootContainer;
    
    private IComponentContainer myDocumentContainer;

    public DocUIManager(IApplicationClass app, IMainForm mainForm, IComponentContainer rootContainer)
    {
      myApp = app;
      myRootContainer = rootContainer;
      myMainForm = mainForm;

      myApp.DocumentChanged += DocumentChanged;
    }

    private void DocumentChanged(object sender, DocumentChangedEventArgs e)
    {
      DisposeDocumentContainer();
      IApplicationDocument document = e.NewDocument;

      var c = CreateContainer(document);

      var f = c.GetComponent<IDocumentMainControl>();
      myMainForm.SetContent(f.Control);
    }

    private IComponentContainer CreateContainer(IApplicationDocument document)
    {
      var c  =
        myRootContainer.SubContainer<DocumentComponent>();
      
      //Predefined container-wide object
      c.RegisterComponent(document);

      c.Start();
      myDocumentContainer = c;
      return c;
    }

    public void Dispose()
    {
      DisposeDocumentContainer();
    }

    private void DisposeDocumentContainer()
    {
      if (myDocumentContainer != null)
      {
        myDocumentContainer.GetComponents<IDocumentComponent>().Each(x => x.BeforeDocumentContainerDisposed());
        myDocumentContainer.Dispose();
        myDocumentContainer = null;
      }
    }
  }
}