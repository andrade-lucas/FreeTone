namespace Tone.Infra.Context
{
    public static class Settings
    {
        public static string ConnectionString
        {
            get
            {
                return @"Server=LUCAS-CDS;Database=FreeTone;Integrated Security=true;User Id=sa;Password=123;";
            }
        }
    }
}