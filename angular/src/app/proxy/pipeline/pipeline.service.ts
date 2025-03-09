import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { PipelineBodyDto, PipelineEndpointDto, PipelineResponseDto } from '../dto/pipeline/models';

@Injectable({
  providedIn: 'root',
})
export class PipelineService {
  apiName = 'Default';
  

  create = (input: PipelineEndpointDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PipelineEndpointDto>({
      method: 'POST',
      url: '/api/app/pipeline',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/pipeline/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, PipelineEndpointDto[]>({
      method: 'GET',
      url: '/api/app/pipeline',
    },
    { apiName: this.apiName,...config });
  

  getTestDataByPipelineId = (pipelineId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: `/api/app/pipeline/test-data/${pipelineId}`,
    },
    { apiName: this.apiName,...config });
  

  getTrainDataByPipelineId = (pipelineId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: `/api/app/pipeline/train-data/${pipelineId}`,
    },
    { apiName: this.apiName,...config });
  

  runPipeline = (input: PipelineBodyDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PipelineResponseDto>({
      method: 'POST',
      url: '/api/app/pipeline/run-pipeline',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
