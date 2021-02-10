using System.Collections.Generic;
using System.Reflection;

using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.Permissions;
using Softeq.XToolkit.Permissions.iOS;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Essentials.ImagePicker;
using Softeq.XToolkit.WhiteLabel.Essentials.iOS.FullScreenImage;
using Softeq.XToolkit.WhiteLabel.Essentials.iOS.ImagePicker;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.iOS;
using Softeq.XToolkit.WhiteLabel.iOS.Services;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.iOS
{
    internal class CustomIosBootstrapper : IosBootstrapperBase
    {
        protected override IList<Assembly> SelectAssemblies()
        {
            return base.SelectAssemblies() // Softeq.XToolkit.WhiteLabel.iOS
                .AddItem(typeof(FullScreenImageViewController).Assembly) // Softeq.XToolkit.WhiteLabel.Essentials.iOS
                .AddItem(GetType().Assembly); // Playground.iOS
        }

        protected override void ConfigureIoc(IContainerBuilder builder)
        {
            // core
            builder.Singleton<IosAppInfoService, IAppInfoService>();

            builder.Singleton<StoryboardDialogsService, IDialogsService>();

            // permissions
            builder.Singleton<PermissionsService, IPermissionsService>();
            builder.Singleton<PermissionsManager, IPermissionsManager>();

            // image picker
            builder.Singleton<IosImagePickerService, IImagePickerService>();
        }
    }
}