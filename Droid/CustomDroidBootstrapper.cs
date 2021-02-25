using System.Collections.Generic;
using System.Reflection;

using InternalLibrary.Services;


using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Droid.Services;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;

namespace InternalLibrary.Droid
{
    public class CustomDroidBootstrapper : DroidBootstrapperBase
    {
        protected override IList<Assembly> SelectAssemblies()
        {
            return base.SelectAssemblies() // Softeq.XToolkit.WhiteLabel.Droid
                .AddItem(GetType().Assembly); // Playground.Droid
        }

        protected override void ConfigureIoc(IContainerBuilder builder)
        {
            // core
            CustomBootstrapper.Configure(builder);

            builder.Singleton<DroidAppInfoService, IAppInfoService>();

            builder.Singleton<AndroidGoogleAPIConfiguration, IGoogleAPIConfoguration>();

            builder.Singleton<DroidFragmentDialogService, IDialogsService>();
        }
    }
}
