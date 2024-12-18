namespace OSA.Utility
{
    public class AppSettings
    {
        public SwaggerDetails SwaggerDetails { get; set; } = new SwaggerDetails();
    }

    public class SwaggerDetails
    {
         public string ValidAudience { get; set; } = string.Empty;
         public string ValidIssuer { get; set; } = string.Empty;
        public int JwtExpiryInMinutes { get; set; } = 0;
        public string Secret { get; set; } = string.Empty;
    }
}
