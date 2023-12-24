namespace AuthorizationWithJWT.JWTTokenOptions
{
    public class JwtOptions
    {
        public string Audience { get; init; }
        public string Issuer { get; init; }
        public string Secret { get; init; }
    }
}
