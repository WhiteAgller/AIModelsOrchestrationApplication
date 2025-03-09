using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Dto.Job;
using MLOps.Entities.Job;
using Volo.Abp.Domain.Repositories;

namespace MLOps.Job;

public class JobAppService: MLOpsAppService, IJobAppService
{
    private readonly IMLOpsClient _mlOpsClient;
    private readonly IRepository<JobStatusEntity, Guid> _jobStatusRepository;
    private readonly IConfigHandler _configHandler;

    public JobAppService(IMLOpsClient mlOpsClient, IRepository<JobStatusEntity, Guid> jobStatusRepository, IConfigHandler configHandler)
    {
        _mlOpsClient = mlOpsClient;
        _jobStatusRepository = jobStatusRepository;
        _configHandler = configHandler;
    }
    
    public async Task<JobGetResponeDto> GetJob(string pipelineId, string experimentId)
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        var response = await client.GetJob(pipelineId, experimentId);
        return ObjectMapper.Map<JobGetResponeEntity, JobGetResponeDto>(response);
    }
    
    public async Task<List<JobStatusDto>> GetListAsync()
    {
        var items = await _jobStatusRepository.GetListAsync();
        return items
            .Select(item => new JobStatusDto()
            {
                Id = item.Id,
                DisplayName = item.DisplayName,
                ExperimentId = item.ExperimentId,
                PipelineId = item.PipelineId
            }).ToList();
    }
    
    public async Task<JobStatusDto> GetAsync(Guid id)
    {
        var item = await _jobStatusRepository.GetAsync(id);
        return new JobStatusDto()
        {
            Id = item.Id,
            DisplayName = item.DisplayName,
            ExperimentId = item.ExperimentId,
            PipelineId = item.PipelineId
        };
    }
    
    public async Task<JobStatusDto> CreateAsync(JobStatusDto job)
    {
        var item = await _jobStatusRepository.InsertAsync(
            new JobStatusEntity {DisplayName = job.DisplayName, ExperimentId = job.ExperimentId, PipelineId = job.PipelineId}
        );

        return new JobStatusDto
        {
            Id = item.Id,
            DisplayName = item.DisplayName,
            ExperimentId = item.ExperimentId,
            PipelineId = item.PipelineId
        };
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _jobStatusRepository.DeleteAsync(id);
    }
    
}