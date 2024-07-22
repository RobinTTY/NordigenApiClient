import type { SidebarsConfig } from "@docusaurus/plugin-content-docs";

const sidebars: SidebarsConfig = {
  sidebar: [
    "intro",
    "quickstart-guide",
    "handling-authentication-tokens",
    "using-a-different-base-address",
    {
      type: "category",
      label: "API Reference",
      items: ["api-reference/nordigen-api-client"],
    },
  ],
};

export default sidebars;
