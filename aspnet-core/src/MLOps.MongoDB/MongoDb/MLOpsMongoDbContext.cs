using MLOps.Entities;
using MLOps.Entities.Config;
using MLOps.Entities.Job;
using MLOps.Entities.Model;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MLOps.MongoDB;

[ConnectionStringName("Default")]
public class MLOpsMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<PipelineEndpointEntity> PipelineEndpoints => Collection<PipelineEndpointEntity>();
    public IMongoCollection<JobStatusEntity> JobStatutes => Collection<JobStatusEntity>();
    public IMongoCollection<ModelsInfoEntity> ModelsInfo => Collection<ModelsInfoEntity>();
    public IMongoCollection<ConfigEntity> Config => Collection<ConfigEntity>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.Entity<PipelineEndpointEntity>(b =>
        {
            b.CollectionName = "PipelineEndpoint";
        });
        
        modelBuilder.Entity<JobStatusEntity>(b =>
        {
            b.CollectionName = "JobStatus";
        });
        
        modelBuilder.Entity<ModelsInfoEntity>(b =>
        {
            b.CollectionName = "Models";
        });
        
        modelBuilder.Entity<ConfigEntity>(b =>
        {
            b.CollectionName = "Config";
        });
    }
}
