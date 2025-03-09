using MLOps.MongoDB;
using Xunit;

namespace MLOps;

[CollectionDefinition(MLOpsTestConsts.CollectionDefinitionName)]
public class MLOpsApplicationCollection : MLOpsMongoDbCollectionFixtureBase
{

}
