var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TCTest_WebApi>("api");

builder.Build().Run();