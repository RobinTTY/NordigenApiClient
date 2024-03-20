import {themes as prismThemes} from 'prism-react-renderer';
import type {Config} from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

const config: Config = {
  title: 'NordigenApiClient',
  tagline: 'A .NET client for GoCardless bank account data (formerly Nordigen API)',
  favicon: 'img/favicon.ico',

  url: 'https://github.com/',
  baseUrl: '/NordigenApiClient/',
  organizationName: 'RobinTTY',
  projectName: 'NordigenApiClient',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',

  i18n: {
    defaultLocale: 'en',
    locales: ['en'],
  },

  presets: [
    [
      'classic',
      {
        docs: {
          sidebarPath: './sidebars.ts',
        },
        blog: {
          id: 'release-notes',
          routeBasePath: 'release-notes',
          path: 'release-notes',
          showReadingTime: true
        },
        theme: {
          customCss: './src/css/custom.css',
        },
      } satisfies Preset.Options,
    ],
  ],

  themeConfig: {
    // Replace with your project's social card
    image: 'img/docusaurus-social-card.jpg',
    navbar: {
      title: 'NordigenApiClient',
      logo: {
        alt: 'NordigenApiClient logo',
        src: 'img/logo.svg',
      },
      items: [
        {
          type: 'docSidebar',
          sidebarId: 'sidebar',
          position: 'left',
          label: 'Docs',
        },
        {to: '/release-notes', label: 'Release Notes', position: 'left'},
        {
          href: 'https://github.com/facebook/docusaurus',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Content',
          items: [
            {
              label: 'Docs',
              to: '/docs/intro',
            },
            {
              label: 'Release Notes',
              to: '/release-notes',
            },
          ],
        },
        {
          title: 'Community',
          items: [
            {
              label: 'GitHub',
              href: 'https://github.com/RobinTTY/NordigenApiClient',
            },
            {
              label: 'Twitter',
              href: 'https://twitter.com/Robin_tty',
            },
          ],
        },
      ],
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
    },
  } satisfies Preset.ThemeConfig,
};

export default config;
