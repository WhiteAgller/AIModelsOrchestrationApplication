import { Injectable } from '@angular/core';
import { ConfigService } from '@proxy/config';


@Injectable({
    providedIn: 'root'
})
export class AvaibleConfigService {

    constructor(private configService: ConfigService){}

    async hasConfig(): Promise<boolean> {
        try {
          const response = await this.configService.getByUserId().toPromise();
          return response != null;
        } catch (error) {
          console.error('Error fetching config:', error);
          return false;
        }
      }
}