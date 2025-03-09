import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { PipelineComponent } from './pipeline.component';
import { PipelineRoutingModule } from './pipeline-routing.module';


@NgModule({
  declarations: [PipelineComponent],
  imports: [SharedModule, PipelineRoutingModule],
})
export class PipelineModule {}
