using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class DocumentManager : IDocumentManager
  {
    [Autowire]
    private IApplicationClass myApplication { get; set;}
    [Autowire]
    private IInvocator myInvocator { get; set; }

    public void ChangeDocument(Context newContext)
    {
      myInvocator.InvokeOrQueue(
        "Create new document",
        delegate
          {
            var ctx = new Context();
            ctx.AddAll(newContext);

            AddIfNoteDefined(ctx, newContext, Keys.SystemSpaceKey);
            AddIfNoteDefined(ctx, newContext, Keys.SystemInfoKey);

            var doc = new ApplicationDocument(myApplication.Document.Title, ctx);
            myApplication.Document = doc;
          });
    }

    private void AddIfNoteDefined<T>(IWriteOnlyContext ctx, IReadOnlyContext newContext, Key<T> key)
    {
      if (!newContext.ContainsKey(key))
      {
        key.Copy(myApplication.Document.Content, ctx);
      }
    }
  }
}