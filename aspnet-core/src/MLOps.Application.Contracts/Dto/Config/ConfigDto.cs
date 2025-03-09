using System;
using Volo.Abp.Application.Dtos;


namespace MLOps.Dto.Config;

public class ConfigDto : EntityDto
{
    public virtual Guid Id { get; set; }
    
    public virtual string Subscription { get; set; }

    public virtual string ResourceGroup { get; set; }

    public virtual string Workspace  { get; set; }

    public virtual string WorkspaceId { get; set; }
    
    public virtual string TenantId { get; set; }

    public virtual string StorageKey { get; set; }

    public virtual string LogBlobContainerName { get; set; }

    public virtual string DataBlobContainerName { get; set; }

    public virtual string LogFolderPath { get; set; }

    public virtual string DataFolderPath { get; set; }
    
    public virtual string ClientId { get; set; }

    public virtual string ClientSecret { get; set; }
    
    public virtual Guid UserId { get; set; }
}