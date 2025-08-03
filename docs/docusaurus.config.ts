import { themes as prismThemes } from "prism-react-renderer";
import type { Config } from "@docusaurus/types";
import type * as Preset from "@docusaurus/preset-classic";

const projectName = "NordigenApiClient";
const githubLabel = "GitHub";
const repositoryUrl = "https://github.com/RobinTTY/NordigenApiClient";

const config: Config = {
  title: projectName,
  favicon: "img/nordigen-logo-min.ico",

  url: "https://github.com/",
  baseUrl: `/${projectName}/`,
  organizationName: "RobinTTY",
  projectName: projectName,
  deploymentBranch: "docs",
  onBrokenLinks: "throw",
  onBrokenMarkdownLinks: "warn",
  trailingSlash: false,

  i18n: {
    defaultLocale: "en",
    locales: ["en"],
  },

  presets: [
    [
      "classic",
      {
        docs: {
          sidebarPath: "./sidebars.ts",
        },
        blog: {
          id: "release-notes",
          routeBasePath: "release-notes",
          path: "release-notes",
          showReadingTime: true,
          onUntruncatedBlogPosts: "ignore",
          blogSidebarTitle: 'Releases',
          blogSidebarCount: 'ALL',
        },
        theme: {
          customCss: "./src/css/custom.css",
        },
      } satisfies Preset.Options,
    ],
  ],

  themeConfig: {
    image: "img/nordigen-logo-min.png",
    navbar: {
      title: projectName,
      logo: {
        alt: "NordigenApiClient logo",
        src: "img/nordigen-logo-min.png",
      },
      items: [
        {
          type: "docSidebar",
          sidebarId: "sidebar",
          position: "left",
          label: "Docs",
        },
        { to: "/release-notes", label: "Release Notes", position: "left" },
        {
          href: repositoryUrl,
          label: githubLabel,
          position: "right",
        },
      ],
    },
    footer: {
      style: "dark",
      links: [
        {
          title: "Content",
          items: [
            {
              label: "Docs",
              to: "/docs/intro",
            },
            {
              label: "Release Notes",
              to: "/release-notes",
            },
          ],
        },
        {
          title: "Community",
          items: [
            {
              label: githubLabel,
              href: repositoryUrl,
            },
            {
              label: "Twitter",
              href: "https://twitter.com/Robin_tty",
            },
          ],
        },
      ],
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
      additionalLanguages: ["powershell", "csharp"],
    },
  } satisfies Preset.ThemeConfig,
};

export default config;
