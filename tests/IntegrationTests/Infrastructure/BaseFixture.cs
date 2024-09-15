using System.Net;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace IntegrationTests.Infrastructure;

public class BaseFixture : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    protected readonly HttpClient Client;

    protected BaseFixture()
    {
        _factory = new WebApplicationFactory<Program>();
        Client = _factory.CreateClient();
    }

    protected StringContent Serialize<T>(T obj)
    {
        return new(
            JsonConvert.SerializeObject(obj),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
    }

    protected T Deserialize<T>(HttpResponseMessage response)
    {
        if (response.StatusCode != HttpStatusCode.OK)
            return default!;

        var content = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public void Dispose()
    {
        Client.Dispose();
        _factory.Dispose();
    }
}