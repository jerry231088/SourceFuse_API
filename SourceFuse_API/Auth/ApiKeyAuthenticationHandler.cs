using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sourcefuse_Api.Auth
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string apiKeyValue = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(apiKeyValue))
            {
                return AuthenticateResult.Fail("API key is missing");
            }

            // Validate the API key
            ApiKey apiKey = _apiKeyRepository.GetByKey(apiKeyValue);

            if (apiKey != null)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, apiKey.Owner),
                new Claim(ClaimTypes.Authentication, apiKeyValue)
            };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API key");
        }
    }

}
