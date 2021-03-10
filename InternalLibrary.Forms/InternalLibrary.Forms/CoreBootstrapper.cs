using System;
using System.Collections.Generic;
using System.Reflection;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Forms;
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

        }
    }
}
