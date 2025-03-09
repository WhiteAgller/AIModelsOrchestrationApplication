import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ConfigRoutingModule } from './config-routing.module';
import { ConfigComponent } from './config.component';


@NgModule({
  declarations: [ConfigComponent],
  imports: [SharedModule, ConfigRoutingModule],
})
export class ConfigModule {}
