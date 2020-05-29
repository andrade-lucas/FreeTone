namespace Tone.Infra.Context
{
    public static class Settings
    {
        public static string ConnectionString
        {
            get
            {
                return @"Server=;Database=;Integrated Security=false;User Id=;Password=;";
            }
        }
    }
}