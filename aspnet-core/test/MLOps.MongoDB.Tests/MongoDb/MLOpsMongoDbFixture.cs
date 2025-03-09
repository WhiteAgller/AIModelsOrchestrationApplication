using System;
using Mongo2Go;

namespace MLOps.MongoDB;

public class MLOpsMongoDbFixture : IDisposable
{
    private static readonly MongoDbRunner MongoDbRunner;
    public static readonly string ConnectionString;

    static MLOpsMongoDbFixture()
    {
        MongoDbRunner = MongoDbRunner.Start(singleNodeReplSet: true, singleNodeReplSetWaitTimeout: 20);
        ConnectionString = MongoDbRunner.ConnectionString;
    }

    public void Dispose()
    {
        MongoDbRunner?.Dispose();
    }
}
