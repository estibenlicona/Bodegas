using Bodegas.Api.Filters;
using Bodegas.Domain.Ports;
using Bodegas.Domain.Services;
using Bodegas.Infrastructure.Adapters;
using Bodegas.Infrastructure.Config;
using Bodegas.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(AgavalExceptionFilterAttribute));
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<PrivadaDbContext>(x => {
    x.UseSqlServer(Environment.GetEnvironmentVariable("DB_SERVER") ?? builder.Configuration.GetConnectionString("SqlConection"))
    .EnableSensitiveDataLogging();
});

builder.Services.AddMediatR(Assembly.Load("Bodegas.Applications"), Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IBodegaServices, BodegaServices>();
builder.Services.AddTransient<ICajaServices, CajaServices>();
builder.Services.AddTransient<IResolucionlServices, ResolucionService>();
builder.Services.AddTransient<ISucursalService, SucursalService>();
builder.Services.AddTransient<ICentroCostoService, CentroCostoService>();
builder.Services.AddTransient<ITerceroService, TerceroService>();
builder.Services.AddTransient<IB2CService, B2CService>();

string urlApiAliado = Environment.GetEnvironmentVariable("API_ALIADO") ?? builder.Configuration.GetValue<string>("ApiAliado");
builder.Services.AddHttpClient<IB2CRepository, B2CRepository>(c => c.BaseAddress = new Uri(urlApiAliado));

ApiAliadosConfig apiAliadosConfig = new ApiAliadosConfig();
apiAliadosConfig.HeaderName = Environment.GetEnvironmentVariable("HEADER_NAME") ?? builder.Configuration.GetValue<string>("ApiKey:HeaderName");
apiAliadosConfig.HeaderValue = Environment.GetEnvironmentVariable("HEADER_VALUE") ?? builder.Configuration.GetValue<string>("ApiKey:HeaderValue");
builder.Services.AddSingleton(x => apiAliadosConfig);

string[] origins = builder.Configuration.GetSection("Cross:UrlOrigins").Get<IEnumerable<string>>().ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builderx => builderx.WithOrigins(origins)
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT")
                            .AllowCredentials());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bodegas Api"));
}

app.UseCors("CorsPolicy");
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();