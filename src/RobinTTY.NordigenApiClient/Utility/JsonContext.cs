using System.Text.Json.Serialization;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Utility;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(NordigenClientCredentials))]
[JsonSerializable(typeof(JsonWebToken))]
[JsonSerializable(typeof(AcceptAgreementRequest))]
[JsonSerializable(typeof(CreateAgreementRequest))]
[JsonSerializable(typeof(CreateRequisitionRequest))]
[JsonSerializable(typeof(NordigenApiResponse<object, object>))]
[JsonSerializable(typeof(ResponsePage<object>))]
[JsonSerializable(typeof(List<object>))]
[JsonSerializable(typeof(AccountTransactions))]
[JsonSerializable(typeof(BankAccountDetails))]
[JsonSerializable(typeof(BankAccount))]
[JsonSerializable(typeof(Balance))]
[JsonSerializable(typeof(Agreement))]
[JsonSerializable(typeof(BasicResponse))]
[JsonSerializable(typeof(Institution))]
[JsonSerializable(typeof(Requisition))]
[JsonSerializable(typeof(BasicError))]
[JsonSerializable(typeof(AccountsError))]
[JsonSerializable(typeof(InstitutionsError))]
[JsonSerializable(typeof(InstitutionsErrorInternal))]
[JsonSerializable(typeof(CreateAgreementError))]
[JsonSerializable(typeof(CreateRequisitionError))]
internal partial class JsonContext : JsonSerializerContext;
