namespace Tone.Shared.Settings
{
    public static class AppSettings
    {
        private readonly static string _tokenKey = "1F6C6101-4F48-4C9A-AA85-59329314B121";
        
        public static string TokenKey 
        { 
            get { return _tokenKey; } 
            private set {  } 
        }
    }
}