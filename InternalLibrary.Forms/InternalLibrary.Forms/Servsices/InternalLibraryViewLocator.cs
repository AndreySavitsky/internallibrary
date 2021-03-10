using Softeq.XToolkit.WhiteLabel.Forms.Navigation;

namespace InternalLibrary.Forms.Servsices
{
    public class InternalLibraryViewLocator : FormsViewLocator
    {
        protected override string BuildPageTypeName(string viewModelTypeName)
        {
            var name = viewModelTypeName
                .Replace(".ViewModels.", ".Views.")
                .Replace("Model", string.Empty);
            return name;
        }
    }
}
