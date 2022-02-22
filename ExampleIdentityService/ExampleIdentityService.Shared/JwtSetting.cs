namespace ExampleIdentityService.Shared
{
    public class JwtSetting
    {
        public string SecurityKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}