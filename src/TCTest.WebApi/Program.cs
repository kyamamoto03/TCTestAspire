using TCTest.Domain.UserModel;
using TCTest.DomainService;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.AddServiceDefaults();

#region DB

builder.AddNpgsqlDbContext<TCTestDB>("tctestdb");

#endregion DB

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDomainServices();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();
var todo = app.MapUserApiV1();

app.Run();