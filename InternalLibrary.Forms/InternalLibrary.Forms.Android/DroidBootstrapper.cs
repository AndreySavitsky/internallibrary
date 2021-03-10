using System.Collections.Generic;
using System.Reflection;
using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;

namespace InternalLibrary.Forms.Droid
{
    public class DroidBootstrapper : CoreBootstrapper
    {
        protected override IList<Assembly> SelectAssemblies()
        {
            return base.SelectAssemblies()
                .AddItem(GetType().Assembly);
        }

        protected override void ConfigureIoc(IContainerBuilder builder)
        {
            base.ConfigureIoc(builder);
        }
    }
}
