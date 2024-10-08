﻿using FakeItEasy;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class RequisitionsEndpointTests
{
    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the retrieving of all existing requisitions.
    /// </summary>
    [Test]
    public async Task GetRequisitions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.GetRequisitions,
            HttpStatusCode.OK);

        var requisitions = await apiClient.RequisitionsEndpoint.GetRequisitions(100, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(requisitions, HttpStatusCode.OK);

        var result = requisitions.Result!;
        var requisition = result.Results.First();
        var expectedAccountGuids = new List<Guid>
            {new("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new("3fa85f64-5717-4562-b3fc-2c963f66afa7")};

        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result.Next,
                Is.EqualTo(new Uri("https://bankaccountdata.gocardless.com/api/v2/requisitions/?limit=100&offset=0")));
            Assert.That(result.Previous,
                Is.EqualTo(new Uri("https://bankaccountdata.gocardless.com/api/v2/requisitions/?limit=100&offset=0")));
            Assert.That(requisition.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));

            Assert.That(requisition.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-12T23:50:34.962Z").ToUniversalTime()));
            Assert.That(requisition.Redirect, Is.EqualTo(new Uri("https://www.robintty.com")));
            Assert.That(requisition.Status, Is.EqualTo(RequisitionStatus.Created));
            Assert.That(requisition.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));

            Assert.That(requisition.AgreementId, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(requisition.Reference, Is.EqualTo("example-reference"));
            Assert.That(requisition.Accounts, Is.EqualTo(expectedAccountGuids));
            Assert.That(requisition.UserLanguage, Is.EqualTo("EN"));

            Assert.That(requisition.AuthenticationLink,
                Is.EqualTo(new Uri(
                    "https://ob.nordigen.com/psd2/start/3fa85f64-5717-4562-b3fc-2c963f66afa6/SANDBOXFINANCE_SFIN0000")));
            Assert.That(requisition.SocialSecurityNumber, Is.EqualTo("555-50-1234"));
            Assert.That(requisition.AccountSelection, Is.False);
            Assert.That(requisition.RedirectImmediate, Is.True);
        });
    }

    /// <summary>
    /// Tests the retrieving of a specific requisition.
    /// </summary>
    [Test]
    public async Task GetRequisition()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.GetRequisition,
            HttpStatusCode.OK);

        var requisition = await apiClient.RequisitionsEndpoint.GetRequisition(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(requisition, HttpStatusCode.OK);
        var expectedAccountGuids = new List<Guid>
            {new("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new("3fa85f64-5717-4562-b3fc-2c963f66afa7")};

        Assert.Multiple(() =>
        {
            Assert.That(requisition.Result!.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(requisition.Result!.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-12T23:50:34.962Z").ToUniversalTime()));
            Assert.That(requisition.Result!.Redirect, Is.EqualTo(new Uri("https://www.robintty.com")));
            Assert.That(requisition.Result!.Status, Is.EqualTo(RequisitionStatus.Created));
            Assert.That(requisition.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));

            Assert.That(requisition.Result!.AgreementId, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(requisition.Result!.Reference, Is.EqualTo("example-reference"));
            Assert.That(requisition.Result!.Accounts, Is.EqualTo(expectedAccountGuids));
            Assert.That(requisition.Result!.UserLanguage, Is.EqualTo("EN"));

            Assert.That(requisition.Result!.AuthenticationLink,
                Is.EqualTo(new Uri(
                    "https://ob.nordigen.com/psd2/start/3fa85f64-5717-4562-b3fc-2c963f66afa6/SANDBOXFINANCE_SFIN0000")));
            Assert.That(requisition.Result!.SocialSecurityNumber, Is.EqualTo("555-50-1234"));
            Assert.That(requisition.Result!.AccountSelection, Is.False);
            Assert.That(requisition.Result!.RedirectImmediate, Is.True);
        });
    }

    /// <summary>
    /// Tests the creation of a new requisition.
    /// </summary>
    [Test]
    public async Task CreateRequisitions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.CreateRequisition,
            HttpStatusCode.Created);

        var requisition = await apiClient.RequisitionsEndpoint.CreateRequisition(A.Dummy<string>(), A.Dummy<Uri>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(requisition, HttpStatusCode.Created);

        Assert.Multiple(() =>
        {
            Assert.That(requisition.Result!.Redirect, Is.EqualTo(new Uri("https://www.robintty.com")));
            Assert.That(requisition.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(requisition.Result!.AgreementId, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(requisition.Result!.Reference, Is.EqualTo("example-reference"));

            Assert.That(requisition.Result!.UserLanguage, Is.EqualTo("EN"));
            Assert.That(requisition.Result!.SocialSecurityNumber, Is.EqualTo("555-50-1234"));
            Assert.That(requisition.Result!.AccountSelection, Is.False);
            Assert.That(requisition.Result!.RedirectImmediate, Is.True);
        });
    }

    /// <summary>
    /// Tests the deletion of a requisition.
    /// </summary>
    [Test]
    public async Task DeleteRequisitions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.DeleteRequisition,
            HttpStatusCode.OK);

        var result = await apiClient.RequisitionsEndpoint.DeleteRequisition(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);

        Assert.Multiple(() =>
        {
            Assert.That(result.Result?.Summary, Is.EqualTo("Requisition deleted"));
            Assert.That(result.Result?.Detail,
                Is.EqualTo(
                    "Requisition b5462cad-5a7f-42e1-881d-d0fa066f54bc deleted with all its End User Agreements"));
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the retrieval of a requisition with an invalid guid.
    /// </summary>
    [Test]
    public async Task GetRequisitionWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.RequisitionsEndpointMockData.GetRequisitionWithInvalidGuid, HttpStatusCode.NotFound);

        var response = await apiClient.RequisitionsEndpoint.GetRequisition(guid);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.NotFound);
            Assert.That(response.Error!.Detail, Is.EqualTo("Not found."));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid id.
    /// </summary>
    [Test]
    public async Task CreateRequisitionWithInvalidId()
    {
        var redirect = new Uri("ftp://ftp.test.com");
        var agreementId = Guid.Empty;
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.RequisitionsEndpointMockData.CreateRequisitionWithInvalidId,
            HttpStatusCode.BadRequest);

        var response = await apiClient.RequisitionsEndpoint.CreateRequisition("123", redirect, agreementId,
            "internal_reference", "EN", null, true, true);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            Assert.That(response.Error!.Summary, Is.EqualTo("Invalid  ID"));
            Assert.That(response.Error!.Detail,
                Is.EqualTo("00000000-0000-0000-0000-000000000000 is not a valid  UUID. "));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid parameters in the <see cref="CreateRequisitionRequest" />.
    /// </summary>
    [Test]
    public async Task CreateRequisitionWithInvalidParameters()
    {
        var redirect = new Uri("ftp://ftp.test.com");
        // Agreement belongs to SANDBOXFINANCE_SFIN0000
        var agreementId = Guid.Parse("f34c3c71-4a62-4a25-b998-3f37ddce84a2");
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.RequisitionsEndpointMockData.CreateRequisitionWithInvalidParameters,
            HttpStatusCode.BadRequest);

        var response =
            await apiClient.RequisitionsEndpoint.CreateRequisition("", redirect, agreementId, "", "AB", "12345", true,
                true);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);

            Assert.That(response.Error!.AccountSelectionError!.Summary, Is.EqualTo("Account selection not supported"));
            Assert.That(response.Error!.AccountSelectionError!.Detail,
                Is.EqualTo("Account selection not supported for "));

            Assert.That(response.Error!.AgreementError!.Summary, Is.EqualTo("Incorrect Institution ID "));
            Assert.That(response.Error!.AgreementError!.Detail,
                Is.EqualTo(
                    "Provided Institution ID: '' for requisition does not match EUA institution ID 'SANDBOXFINANCE_SFIN0000'. Please provide correct institution ID: 'SANDBOXFINANCE_SFIN0000'"));

            Assert.That(response.Error!.InstitutionIdError!.Summary, Is.EqualTo("This field may not be blank."));
            Assert.That(response.Error!.InstitutionIdError!.Detail, Is.EqualTo("This field may not be blank."));

            Assert.That(response.Error!.ReferenceError!.Summary, Is.EqualTo("This field may not be blank."));
            Assert.That(response.Error!.ReferenceError!.Detail, Is.EqualTo("This field may not be blank."));

            Assert.That(response.Error!.SocialSecurityNumberError!.Summary,
                Is.EqualTo("SSN verification not supported"));
            Assert.That(response.Error!.SocialSecurityNumberError!.Detail,
                Is.EqualTo("SSN verification not supported for "));

            Assert.That(response.Error!.UserLanguageError!.Summary,
                Is.EqualTo("Provided user_language is invalid or not supported"));
            Assert.That(response.Error!.UserLanguageError!.Detail,
                Is.EqualTo("'AB' is an invalid or unsupported language"));
        });
    }

    #endregion
}