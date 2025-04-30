using System.Text;
using System.Threading.RateLimiting;
using MARSX.GPS.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WatchDog;
using WatchDog.src.Enums;
using Hangfire;
using Hangfire.PostgreSql;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using MARSX.GPS.API.Controllers;
using MARSX.GPS.API.Repositories.AutoInterfaceRepositories;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Hangfire.Dashboard;
using MARSX.GPS.API.Services.Extension;

IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();


var connectionString = configuration.GetConnectionString("ConnectionStr");

var builder = WebApplication.CreateBuilder(args);


#region HangfireZone

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(connectionString));

builder.Services.AddHangfireServer();

#endregion

#region Logging Watchdog Zone

builder.Logging.AddWatchDogLogger();

builder.Services.AddWatchDogServices();
builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = true;
    opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Weekly;

    opt.SetExternalDbConnString = connectionString;
    opt.DbDriverOption = WatchDogDbDriverEnum.PostgreSql;
});


#endregion


builder.Services.AddDbContext<TrackerContext>();

// Add JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            //ValidIssuer = configuration["Jwt:Issuer"],
            //ValidAudience = configuration["Jwt:Audience"]
        };
    });


// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MARSX THINGS.CO.,LTD | GPS APPLICATION API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter the JWT token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 500,
                QueueLimit = 100,
                Window = TimeSpan.FromSeconds(1)
            }));

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;

        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
                $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s). " +
                $"Read more about our rate limits at.", cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
                "Too many requests. Please try again later. " +
                "Read more about our rate limits at.", cancellationToken: token);
        }
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.WithOrigins().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true) // allow any origin
       .AllowCredentials().Build();
    });
});


builder.Services.AddDbContext<TrackerContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IAutoInterfaceRepositories, AutoInterfaceRepositories>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.UseRateLimiter();

app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = configuration["WatchDogLogging:username"];
    opt.WatchPagePassword = configuration["WatchDogLogging:password"];
});


#region Hangfire Zome

app.UseHangfireServer();

var options = new DashboardOptions()
{
    Authorization = new[] { new MyAuthorizationFilter() }
};

//app.UseHangfireDashboard();

app.UseHangfireDashboard("/hangfire", options);


using (var server = new BackgroundJobServer())
{
    // Schedule recurring job
    //RecurringJob.AddOrUpdate<AutoInterfaceController>(x => x.SyncDeviceFromCarTrackService(), Cron.Hourly);

    string cartrack = "Interface Cartrack device";

    string tc = "Interface Track car device";


    var thaiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"); // "SE Asia Standard Time" is the IANA time zone ID for Thailand

    RecurringJob.AddOrUpdate<IAutoInterfaceRepositories>(
            cartrack,
            x => x.SyncDeviceFromCarTrackService(),
            Cron.Hourly,
            new RecurringJobOptions { TimeZone = thaiTimeZone });


    RecurringJob.AddOrUpdate<IAutoInterfaceRepositories>(
            tc,
            x => x.SyncDeviceFromTcService(),
            Cron.Hourly,
            new RecurringJobOptions { TimeZone = thaiTimeZone });

}

#endregion

app.Run();


public class MyAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}


