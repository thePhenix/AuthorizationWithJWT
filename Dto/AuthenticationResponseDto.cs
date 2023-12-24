namespace AuthorizationWithJWT.Dto
{
    public class AuthenticationResponseDto
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string AuthenticationErrorMessage { get; set; }

        public static AuthenticationResponseDto GetUnauthenticatedResponse(string message)
        {
            return new()
            {
                IsAuthenticated = false,
                AuthenticationErrorMessage = message
            };
        }
    }
}
