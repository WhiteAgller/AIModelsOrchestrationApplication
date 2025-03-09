import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'config',
    pathMatch: 'full',
    loadChildren: () => import('./config/config.module').then(m => m.ConfigModule),
  },
  {
    path: 'pipelines_jobs',
    pathMatch: 'full',
    loadChildren: () => import('./pipeline-job/pipeline-job.module').then(m => m.PipelineJobModule),
  },
  {
    path: 'models',
    pathMatch: 'full',
    loadChildren: () => import('./model/model.module').then(m => m.ModelModule),
  },
  {
    path: 'datasets',
    pathMatch: 'full',
    loadChildren: () => import('./dataset/dataset.module').then(m => m.DatasetModule),
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
