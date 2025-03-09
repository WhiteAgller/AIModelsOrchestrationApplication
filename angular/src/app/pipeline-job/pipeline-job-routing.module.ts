import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PipelineJobComponent } from './pipeline-job.component';


const routes: Routes = 
[
  { path: '', component: PipelineJobComponent }, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PipelineJobRoutingModule {}
