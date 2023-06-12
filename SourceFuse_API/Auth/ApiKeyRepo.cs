namespace Sourcefuse_Api.Auth
{
    public class ApiKeyRepo : IApiKeyRepo
    {
        public ApiKey GetByKey(string key)
        {
            return new ApiKey { Key = key, Owner = "SourceFuse" };
        }
    }
}
