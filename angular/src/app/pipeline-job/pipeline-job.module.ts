import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { JobComponent } from '../job/job.component';
import { PipelineJobRoutingModule } from './pipeline-job-routing.module';
import { PipelineJobComponent } from './pipeline-job.component';
import { PipelineComponent } from '../pipeline/pipeline.component';

@NgModule({
  declarations: [
    JobComponent,
    PipelineComponent,
    PipelineJobComponent
  ],
  imports: [SharedModule, PipelineJobRoutingModule],
})
export class PipelineJobModule {}
