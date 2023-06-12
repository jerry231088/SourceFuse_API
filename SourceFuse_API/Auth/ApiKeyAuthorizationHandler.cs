using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sourcefuse_Api.Auth
{
    public class ApiKeyAuthorizationHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IApiKeyRepo _apiKeyRepository;

        public ApiKeyAuthorizationHandler(IApiKeyRepo apiKeyRepository)
        {
            _apiKeyRepository = apiKeyRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail(); // When the user is not authenticated
                return Task.CompletedTask;
            }

            string apiKeyValue = context.User.FindFirstValue(ClaimTypes.Authentication);
            ApiKey apiKey = _apiKeyRepository.GetByKey(apiKeyValue);

            if (apiKey != null)
            {
                // Add any additional checks or validations for the API key, such as expiration date or permissions
                context.Succeed((IAuthorizationRequirement)requirement); // When the API key is valid
            }
            else
            {
                context.Fail(); // When the API key is invalid
            }

            return Task.CompletedTask;
        }
    }

}
