import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ExperimentGetResponseDto } from '../dto/experiment/models';

@Injectable({
  providedIn: 'root',
})
export class ExperimentService {
  apiName = 'Default';
  

  getAllExperiments = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExperimentGetResponseDto[]>({
      method: 'GET',
      url: '/api/app/experiment/experiments',
    },
    { apiName: this.apiName,...config });
  

  getExperimentIdByExperimentName = (experimentName: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/experiment/experiment-id',
      params: { experimentName },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
