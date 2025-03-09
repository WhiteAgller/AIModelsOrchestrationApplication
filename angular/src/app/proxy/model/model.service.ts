import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ModelGetDetailDto, ModelGetVersionsDto, ModelsInfoDto } from '../dto/model/models';
import type { ModelType } from '../model-type.enum';

@Injectable({
  providedIn: 'root',
})
export class ModelService {
  apiName = 'Default';
  

  create = (input: ModelsInfoDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelsInfoDto>({
      method: 'POST',
      url: '/api/app/model',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/model/${id}`,
    },
    { apiName: this.apiName,...config });
  

  deployModelByPipelineIdAndPortAndPipelineName = (pipelineId: string, port: string, pipelineName: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: `/api/app/model/deploy-model/${pipelineId}`,
      params: { port, pipelineName },
    },
    { apiName: this.apiName,...config });
  

  getDataDriftByPort = (port: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/model/data-drift',
      params: { port },
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelsInfoDto[]>({
      method: 'GET',
      url: '/api/app/model',
    },
    { apiName: this.apiName,...config });
  

  getModelByPipelineId = (pipelineId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: `/api/app/model/model/${pipelineId}`,
    },
    { apiName: this.apiName,...config });
  

  getModelLatestVersionByPipelineId = (pipelineId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelGetDetailDto>({
      method: 'GET',
      url: `/api/app/model/model-latest-version/${pipelineId}`,
    },
    { apiName: this.apiName,...config });
  

  getModelVersionsByPipelineId = (pipelineId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelGetVersionsDto>({
      method: 'GET',
      url: `/api/app/model/model-versions/${pipelineId}`,
    },
    { apiName: this.apiName,...config });
  

  getPerformanceByPortAndTypeAndJson = (port: string, type: ModelType, json: boolean, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/model/performance',
      params: { port, type, json },
    },
    { apiName: this.apiName,...config });
  

  predictByPortAndInput = (port: string, input: object[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/model/predict',
      params: { port },
      body: input,
    },
    { apiName: this.apiName,...config });
  

  update = (input: ModelsInfoDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/model',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
