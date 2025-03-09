import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ConfigDto } from '../dto/config/models';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  apiName = 'Default';
  

  createByInput = (input: ConfigDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ConfigDto>({
      method: 'POST',
      url: '/api/app/config',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/config/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ConfigDto>({
      method: 'GET',
      url: `/api/app/config/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getByUserId = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ConfigDto>({
      method: 'GET',
      url: '/api/app/config/by-user-id',
    },
    { apiName: this.apiName,...config });
  

  update = (input: ConfigDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ConfigDto>({
      method: 'PUT',
      url: '/api/app/config',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
