using CorLoan.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using NLog.Fluent;

//public IConfiguration Configuration { get; }
//public string CorsPolicy { get; } = "CORSPolicy";
AppContext.SetSwitch("Switch.System.Runtime.Serialization.UseUnsafeTypeForwarders", false);
//var log = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddControllers().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
var corsPolicy = "CORSPolicy";
builder.Services.ConfigureCors(corsPolicy);

builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureJWTAuthentication(builder.Configuration);
builder.Services.ConfigureOracleContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureAutoMapper();

builder.Services.AddHttpContextAccessor(); //Added to Access Http Context
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//using Microsoft.AspNetCore.Builder;
////using RefactorAspNetWebAPI.Infrastructure.Persistence.Contexts;
////using Serilog;
//using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
////using RefactorAspNetWebAPI.Application;
////using RefactorAspNetWebAPI.Infrastructure.Persistence;
////using RefactorAspNetWebAPI.Infrastructure.Persistence.Contexts;
////using RefactorAspNetWebAPI.Infrastructure.Shared;
////using RefactorAspNetWebAPI.WebApi.Extensions;
//using NLog.Fluent;

//try
//{
//    var builder = WebApplication.CreateBuilder(args);
//    // load up serilog configuraton

//    Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .CreateLogger();
//    builder.Host.UseSerilog(Log.Logger);

//    builder.Services.AddApplicationLayer();
//    builder.Services.AddPersistenceInfrastructure(builder.Configuration);
//    builder.Services.AddSharedInfrastructure(builder.Configuration);
//    builder.Services.AddSwaggerExtension();
//    builder.Services.AddControllersExtension();
//    // CORS
//    builder.Services.AddCorsExtension();
//    builder.Services.AddHealthChecks();
//    //API Security
//    builder.Services.AddJWTAuthentication(builder.Configuration);
//    builder.Services.AddAuthorizationPolicies(builder.Configuration);
//    // API version
//    builder.Services.AddApiVersioningExtension();
//    // API explorer
//    builder.Services.AddMvcCore()
//        .AddApiExplorer();
//    // API explorer version
//    builder.Services.AddVersionedApiExplorerExtension();

//    var app = builder.Build();
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//    }
//    else
//    {
//        app.UseExceptionHandler("/Error");
//        app.UseHsts();
//    }

//    using (var scope = app.Services.CreateScope())
//    {
//        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//        // use context
//        dbContext.Database.EnsureCreated();
//    }

//    // Add this line; you'll need `using Serilog;` up the top, too
//    app.UseSerilogRequestLogging();
//    app.UseHttpsRedirection();
//    app.UseRouting();
//    //Enable CORS
//    app.UseCors("AllowAll");
//    app.UseAuthentication();
//    app.UseAuthorization();
//    app.UseSwaggerExtension();
//    app.UseErrorHandlingMiddleware();
//    app.UseHealthChecks("/health");

//    app.MapControllers();
//    app.Run();

//    Log.Information("Application Starting");

//}
//catch (Exception ex)
//{
//    Log.Warning(ex, "An error occurred starting the application");
//}
//finally
//{
//    Log.CloseAndFlush();
//}