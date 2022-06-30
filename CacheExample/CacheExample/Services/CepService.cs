using RestSharp;

namespace CacheExample.Services;

public class CepService: ICepService
{
    public async ValueTask<Endereco> GetEndereco(string cep)
    {
        var client = new RestClient("https://viacep.com.br/ws");
        var request = new RestRequest($"{cep}/json");

        return await client.GetAsync<Endereco>(request);
    }
}