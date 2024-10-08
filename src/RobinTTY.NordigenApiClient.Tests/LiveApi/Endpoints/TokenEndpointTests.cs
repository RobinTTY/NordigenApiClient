﻿using RobinTTY.NordigenApiClient.Events;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

public class TokenEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the retrieving and refreshing of the JWT access tokens.
    /// </summary>
    [Test]
    public async Task GetJsonWebTokenPairAndRefresh()
    {
        var response = await _apiClient.TokenEndpoint.GetTokenPair();
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await _apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests using the API with an expired access token.
    /// Requires secrets.txt to contain expired access token / valid refresh token pair.
    /// </summary>
    [Test]
    public async Task ReuseExpiredToken()
    {
        var httpClient = new HttpClient();
        var credentials =
            new NordigenClientCredentials(TestHelpers.Secrets.ValidSecretId, TestHelpers.Secrets.ValidSecretKey);
        var tokenPair = new JsonWebTokenPair(TestHelpers.Secrets.ExpiredJwtAccessToken,
            TestHelpers.Secrets.ValidJwtRefreshToken);
        var apiClient = new NordigenClient(httpClient, credentials, tokenPair);

        var result = await apiClient.RequisitionsEndpoint.GetRequisitions(10, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests whether the <see cref="NordigenClient.TokenPairUpdated" /> event is raised when the token pair is updated
    /// automatically by the client itself.
    /// </summary>
    [Test]
    public async Task TokenPairUpdateIsRaisedOnInternalUpdate()
    {
        TokenPairUpdatedEventArgs? eventArgs = null;

        _apiClient.TokenPairUpdated += (_, e) => eventArgs = e;

        await _apiClient.AccountsEndpoint.GetAccount(TestHelpers.Secrets.ValidAccountId);

        Assert.Multiple(() =>
        {
            Assert.That(eventArgs, Is.Not.Null);
            Assert.That(eventArgs!.JsonWebTokenPair, Is.Not.Null);
            Assert.That(eventArgs.JsonWebTokenPair.AccessToken.EncodedToken, Is.Not.Empty);
            Assert.That(eventArgs.JsonWebTokenPair.RefreshToken.EncodedToken, Is.Not.Empty);
        });
    }

    /// <summary>
    /// Tests whether the <see cref="NordigenClient.TokenPairUpdated" /> event is raised when the token pair is updated
    /// by the user.
    /// </summary>
    [Test]
    public void TokenPairUpdateIsRaisedOnManualUpdate()
    {
        TokenPairUpdatedEventArgs? eventArgs = null;

        _apiClient.TokenPairUpdated += (_, e) => eventArgs = e;

        _apiClient.JsonWebTokenPair = new JsonWebTokenPair(TestHelpers.Secrets.ExpiredJwtAccessToken,
            TestHelpers.Secrets.ValidJwtRefreshToken);

        Assert.Multiple(() =>
        {
            Assert.That(eventArgs, Is.Not.Null);
            Assert.That(eventArgs!.JsonWebTokenPair, Is.Not.Null);
            Assert.That(eventArgs.JsonWebTokenPair.AccessToken.EncodedToken, Is.Not.Empty);
            Assert.That(eventArgs.JsonWebTokenPair.RefreshToken.EncodedToken, Is.Not.Empty);
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests retrieving a token with invalid credentials.
    /// </summary>
    [Test]
    public async Task GetTokenWithInvalidCredentials()
    {
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials("invalid", "invalid");
        var apiClient = new NordigenClient(httpClient, credentials);
        var response = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Result, Is.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Error, Is.Not.Null);
        });
    }

    #endregion
}