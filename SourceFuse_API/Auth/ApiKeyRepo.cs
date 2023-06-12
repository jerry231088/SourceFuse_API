using System;
namespace Sourcefuse_Api.Auth
{
    public class ApiKeyRepo : IApiKeyRepo
    {
        // Implement the GetByKey method to retrieve the API key by its value from the data source
        public ApiKey GetByKey(string key)
        {
            // Retrieve the API key from the data source
            // Implement your logic here to retrieve the key and its associated owner

            // Return the API key object
            return new ApiKey { Key = key, Owner = "John Doe" };
        }
    }
}
