using Microsoft.Extensions.Caching.Memory;

namespace CacheExample.Services;

public class CachedCepService : ICepService
{
    private readonly ICepService _service;
    private readonly IMemoryCache _cache;

    public CachedCepService(ICepService service, IMemoryCache cache)
    {
        _service = service;
        _cache = cache;
    }

    public async ValueTask<Endereco> GetEndereco(string cep)
    {
        return await _cache.GetOrCreateAsync(cep, async x =>
        {
            x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            return await _service.GetEndereco(x.Key.ToString()!);
        });
    }
}