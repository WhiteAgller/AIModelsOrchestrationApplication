import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { JobGetResponeDto, JobStatusDto } from '../dto/job/models';

@Injectable({
  providedIn: 'root',
})
export class JobService {
  apiName = 'Default';
  

  create = (job: JobStatusDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, JobStatusDto>({
      method: 'POST',
      url: '/api/app/job',
      body: job,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/job/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, JobStatusDto>({
      method: 'GET',
      url: `/api/app/job/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getJobByPipelineIdAndExperimentId = (pipelineId: string, experimentId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, JobGetResponeDto>({
      method: 'GET',
      url: '/api/app/job/job',
      params: { pipelineId, experimentId },
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, JobStatusDto[]>({
      method: 'GET',
      url: '/api/app/job',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
