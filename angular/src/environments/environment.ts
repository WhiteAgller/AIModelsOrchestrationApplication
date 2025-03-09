import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'MLOps',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44316/',
    redirectUri: baseUrl,
    clientId: 'MLOps_App',
    responseType: 'code',
    scope: 'offline_access MLOps',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44316',
      rootNamespace: 'MLOps',
    },
  },
} as Environment;
