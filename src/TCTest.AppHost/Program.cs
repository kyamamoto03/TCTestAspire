var builder = DistributedApplication.CreateBuilder(args);

var pgPassword = builder.AddParameter("postgres-password");

var postgres = builder.AddPostgres("postgres", null, pgPassword, 15443)
    .WithDataVolume("tctestdb-data")
    .WithInitBindMount("./data")
    .WithPgWeb();

var tctestdb = postgres.AddDatabase("tctestdb");

builder.AddProject<Projects.TCTest_WebApi>("api")
    .WithReference(tctestdb)
    .WaitFor(tctestdb);

builder.Build().Run();