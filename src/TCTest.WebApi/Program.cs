using Microsoft.EntityFrameworkCore;
using TCTest.Domain.UserModel;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

#region DB

builder.Services.AddDbContext<TCTestDB>(options =>
{
    //ConnectionStrings����ǂݍ���
    var conn = builder.Configuration.GetConnectionString("TCTestDB");
    options.UseNpgsql(conn);
});

#endregion DB

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();
var todo = app.MapUserApiV1();

app.Run();