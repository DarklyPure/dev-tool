var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TheGarden_MAUI>("thegarden-maui");

builder.Build().Run();
