using Asp.Versioning;
using Shawa.Api;
using Shawa.Api.Services;
using Shawa.Application.Services;
using Shawa.Infrastructure;
using Shawa.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureEnvironments();

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));

builder.Services.AddControllers();

builder.Services.AddMongoDbContext();
builder.Services.AddAutoMapper();

builder.Services.AddAutoMapperDto();

builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1,0);
});

builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<IOrderService, OrderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
