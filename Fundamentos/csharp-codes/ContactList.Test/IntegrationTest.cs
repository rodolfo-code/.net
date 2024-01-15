namespace ContactList.Test;

using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

using ContactList.Models;
using ContactList.Services;
using ContactList.Controllers;
using System.Text;

public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient _clientTest;
    public Mock<IContactService> mockService;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        mockService = new Mock<IContactService>();
        _clientTest = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IContactService));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();
    }


    [Theory(DisplayName = "Testando a rota /GET Person")]
    [InlineData("/person")]
    public async Task TestGetPerson(string url)
    {
        // Arrange
        Person[] personMoq = new Person[2];
        personMoq[0] = new Person { PersonId = 1, PersonName = "Maria", PersonEmail = "maria@betrybe.com", PersonPhone = "5511999999999" };
        personMoq[1] = new Person { PersonId = 2, PersonName = "João", PersonEmail = "joao@betrybe.com", PersonPhone = "5511988888888" };
        mockService.Setup(s => s.getPersonList()).Returns(personMoq);

        // Act
        var response = await _clientTest.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        Person[] jsonResponse = JsonConvert.DeserializeObject<Person[]>(responseString);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
        Assert.Equal(2, jsonResponse.Count()!);
        Assert.Equal(personMoq[0].PersonId, jsonResponse[0].PersonId);
        Assert.Equal(personMoq[0].PersonName, jsonResponse[0].PersonName);
        Assert.Equal(personMoq[0].PersonPhone, jsonResponse[0].PersonPhone);
        Assert.Equal(personMoq[0].PersonEmail, jsonResponse[0].PersonEmail);
    }

    [Theory(DisplayName = "Testando a rota/POST Person")]
    [InlineData("/person")]
    public async Task TestPostPerson(string url)
    {
        // Arrange
        Person newPerson = new Person { PersonId = 3, PersonName = "Fonzie", PersonEmail = "fonzie@betrybe.com", PersonPhone = "928112686" };
        mockService.Setup(s => s.addPerson(It.IsAny<Person>())).Returns(newPerson);

        // Act
        var inputObj = new
        {
            PersonName = "Rebeca",
            PersonEmail = "rebeca@betrybe.com",
            PersonPhone = "5511977777777"
        };

        var parsedInput = JsonConvert.SerializeObject(inputObj);
        var parsePerson = new StringContent(parsedInput, Encoding.UTF8, "application/json");
        var response = await _clientTest.PostAsync(url, parsePerson);
        var responseString = await response.Content.ReadAsStringAsync();
        Person jsonResponse = JsonConvert.DeserializeObject<Person>(responseString);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Created, response?.StatusCode);
        Assert.Equal(newPerson.PersonId, jsonResponse.PersonId);
        Assert.Equal(newPerson.PersonName, jsonResponse.PersonName);
        Assert.Equal(newPerson.PersonPhone, jsonResponse.PersonPhone);
        Assert.Equal(newPerson.PersonEmail, jsonResponse.PersonEmail);
    }
}