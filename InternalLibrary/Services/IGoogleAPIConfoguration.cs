namespace InternalLibrary.Services
{
    public interface IGoogleAPIConfoguration
    {
        public string ClientID { get; }
        public string RedirectUrl { get; }
        public string Scope { get; }
    }
}
