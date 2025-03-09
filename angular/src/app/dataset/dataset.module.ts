import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { DatasetRoutingModule } from './dataset-routing.module';
import { DatasetComponent } from './dataset.component';


@NgModule({
  declarations: [DatasetComponent],
  imports: [SharedModule, DatasetRoutingModule],
})
export class DatasetModule {}
