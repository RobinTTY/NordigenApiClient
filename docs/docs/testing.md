---
title: Testing
---

You can quite easily test this library without executing real requests. To do that just mock any of the endpoints using their interface (e.g. `IInstitutionsEndpoint`). Alternatively you can also use the `INordigenClient` directly.

## Example

```csharp
using System.Net;
using Moq;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Mocking;

public class AccountsEndpointTests
{
    [Test]
    public async Task Test()
    {
        // Arrange
        var institutionsEndpointMock = new Mock<IInstitutionsEndpoint>();
        var institutionId = "some_id";
        institutionsEndpointMock.Setup(expression: s => s.GetInstitution(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            new NordigenApiResponse<Institution, BasicError>(HttpStatusCode.OK, true,
                new Institution(institutionId, "NAME", "BIC", 90,
                    new List<string>(), new Uri("https://example.com")), null)
        );

        // Act
        var response = await institutionsEndpointMock.Object.GetInstitution(institutionId);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Error, Is.Null);
            Assert.That(response.Result?.Id, Is.EqualTo(institutionId));
        });

       // Alternatively also using NordigenClient mock
        var nordigenClientMock = new Mock<INordigenClient>();
        nordigenClientMock.Setup(s => s.InstitutionsEndpoint).Returns(institutionsEndpointMock.Object);

        var response2 = await nordigenClientMock.Object.InstitutionsEndpoint.GetInstitution(institutionId);

        Assert.Multiple(() =>
        {
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response2.Error, Is.Null);
            Assert.That(response2.Result?.Id, Is.EqualTo(institutionId));
        });

    }
}
```
