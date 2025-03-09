import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ModelComponent } from './model.component';
import { ModelRoutingModule } from './model-routing.module';

@NgModule({
  declarations: [
    ModelComponent
  ],
  imports: [SharedModule, ModelRoutingModule],
})
export class ModelModule {}
