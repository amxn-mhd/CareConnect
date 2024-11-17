namespace CareConnect.Services.AuthApi.models
{
    public class JwtOptions
    {
        public string Issuer { get; set; } 
        public string Audience { get; set; } 
        public string Secret { get; set; } 
    }
}
