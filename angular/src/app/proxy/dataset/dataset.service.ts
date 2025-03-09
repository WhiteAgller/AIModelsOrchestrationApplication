import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DatasetGetResponseDto, DatasetPutRequesetDto, DatasetPutResponseDto } from '../dto/dataset/models';

@Injectable({
  providedIn: 'root',
})
export class DatasetService {
  apiName = 'Default';
  

  createOrUpdateDatasetByInput = (input: DatasetPutRequesetDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DatasetPutResponseDto>({
      method: 'POST',
      url: '/api/app/dataset/or-update-dataset',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  getDatasets = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DatasetGetResponseDto>({
      method: 'GET',
      url: '/api/app/dataset/datasets',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
