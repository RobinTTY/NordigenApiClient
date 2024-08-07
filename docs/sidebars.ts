import type { SidebarsConfig } from "@docusaurus/plugin-content-docs";

const sidebars: SidebarsConfig = {
  sidebar: [
    "intro",
    "quickstart-guide",
    "handling-api-responses",
    "handling-authentication-tokens",
    "using-a-different-base-address",
    "testing",
    {
      type: "category",
      label: "API Reference",
      items: [
        "api-reference/nordigen-client",
        {
          type: "category",
          label: "Endpoints",
          items: [
            "api-reference/endpoints/token-endpoint",
            "api-reference/endpoints/institutions-endpoint",
            "api-reference/endpoints/agreements-endpoint",
            "api-reference/endpoints/requisitions-endpoint",
            "api-reference/endpoints/accounts-endpoint",
          ],
        },
        {
          type: "category",
          label: "Responses",
          items: [
            "api-reference/responses/access-scope",
            "api-reference/responses/account-details",
            "api-reference/responses/account-transactions",
            "api-reference/responses/address",
            "api-reference/responses/agreement",
            "api-reference/responses/amount-currency-pair",
            "api-reference/responses/balance",
            "api-reference/responses/balance-type",
            "api-reference/responses/bank-account",
            "api-reference/responses/bank-account-details",
            "api-reference/responses/bank-account-status-enum",
            "api-reference/responses/bank-account-usage",
            "api-reference/responses/basic-response",
            "api-reference/responses/cash-account-type",
            "api-reference/responses/currency-exchange",
            "api-reference/responses/institution",
            "api-reference/responses/iso-bank-account-status",
            "api-reference/responses/minimal-bank-account",
            "api-reference/responses/nordigen-api-response",
            "api-reference/responses/payment-product",
            "api-reference/responses/requisition",
            "api-reference/responses/requisition-status",
            "api-reference/responses/response-page",
            "api-reference/responses/transaction",
          ],
        },
        {
          type: "category",
          label: "Errors",
          items: [
            "api-reference/errors/accounts-error",
            "api-reference/errors/create-agreement-error",
            "api-reference/errors/create-requisition-error",
          ],
        },
      ],
    },
  ],
};

export default sidebars;
