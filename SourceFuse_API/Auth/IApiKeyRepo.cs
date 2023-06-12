using System;
namespace Sourcefuse_Api.Auth
{
    public interface IApiKeyRepo
    {
        ApiKey GetByKey(string key);
    }
}
