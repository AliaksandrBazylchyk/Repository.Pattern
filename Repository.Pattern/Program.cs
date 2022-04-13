// Business Logic Layer
using Repository.Pattern.BLL.Base;
using Repository.Pattern.BLL.Base.Implementation;
using Repository.Pattern.BLL.Services;
using Repository.Pattern.BLL.Services.Implementation;

// Common Layer
using Repository.Pattern.Common.Options;

// Data Access Layer
using Repository.Pattern.DAL.Base;
using Repository.Pattern.DAL.Base.Implementation;
using Repository.Pattern.DAL.Contexts;
using Repository.Pattern.DAL.Repositories;
using Repository.Pattern.DAL.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostgresDbContext>();

// Options loader section
builder.Services.Configure<ConnectionStrings>(
    builder.Configuration.GetSection(ConnectionStrings.Section));

// Repositories loader section
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IExampleRepository), typeof(ExampleRepository));

// Services loader section
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IExampleService), typeof(ExampleService));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();