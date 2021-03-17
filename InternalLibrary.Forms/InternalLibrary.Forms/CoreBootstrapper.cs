using System;
using System.Collections.Generic;
using System.Reflection;
using InternalLibrary.Forms.Servsices;
using InternalLibrary.Forms.ViewModels;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Forms;
using Softeq.XToolkit.WhiteLabel.Forms.Navigation;
using Xamarin.Forms;

namespace InternalLibrary.Forms
{
    public class CoreBootstrapper : FormsBootstrapper
    {
        protected override IList<Assembly> SelectAssemblies()
        {
            return new List<Assembly>
            {
                typeof(App).Assembly
            };
        }

        protected override bool IsExtractToAssembliesCache(Type type)
        {
            return typeof(Page).IsAssignableFrom(type);
        }

        protected override void ConfigureIoc(IContainerBuilder builder)
        {
            builder.PerDependency<BookListViewModel>();

            builder.Singleton<InternalLibraryViewLocator, IFormsViewLocator>(IfRegistered.Replace);

            builder.Singleton<WebAuthenticatorService, IWebAuthenticatorService>();
        }
    }
}
