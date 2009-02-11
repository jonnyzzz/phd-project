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
            var ctx = UpdateContext(myApplication.Document.Content, newContext);

            var doc = new ApplicationDocument(myApplication.Document.Title, ctx);
            myApplication.Document = doc;
          });
    }

    public Context UpdateContext(IReadOnlyContext currentContext, Context newContext)
    {
      var ctx = new Context();
      ctx.AddAll(newContext);

      AddIfNoteDefined(currentContext, ctx, newContext, Keys.SystemSpaceKey);
      AddIfNoteDefined(currentContext, ctx, newContext, Keys.SystemInfoKey);
      return ctx;
    }

    private static void AddIfNoteDefined<T>(IReadOnlyContext document, IWriteOnlyContext ctx, IReadOnlyContext newContext, Key<T> key)
    {
      if (!newContext.ContainsKey(key))
      {
        key.Copy(document, ctx);
      }
    }
  }
}