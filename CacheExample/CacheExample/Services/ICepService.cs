namespace CacheExample.Services;

public interface ICepService
{
    ValueTask<Endereco> GetEndereco(string cep);
}