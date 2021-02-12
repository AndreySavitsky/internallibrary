using InternalLibrary.Services;

using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;

namespace InternalLibrary
{
    public static class CustomBootstrapper
    {
        public static void Configure(IContainerBuilder builder)
        {
            builder.Singleton<BookRepository, IBookRepository>();
        }
    }
}
