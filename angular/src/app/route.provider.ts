import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: 'Menu',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
    ]);
    routesService.add([{
      path: './datasets',
      name: 'Datasety',
      order: 2,
    }]);
    routesService.add([{
      path: './config',
      name: 'Konfigurace',
      order: 4,
    }]);
    routesService.add([{
      path: './pipelines_jobs',
      name: 'Pipeliny & Práce',
      order: 2,
    }]);
    routesService.add([{
      path: './models',
      name: 'Modely',
      order: 3,
    }]);
  };
}
