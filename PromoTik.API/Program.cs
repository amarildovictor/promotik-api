using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PromoTik.Data.Context;
using PromoTik.Data.Repositories;
using PromoTik.Data.Repositories.Scheduled;
using PromoTik.Domain.Entities.Auth;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Repositories.Scheduled;
using PromoTik.Domain.Interfaces.Services;
using PromoTik.Domain.Interfaces.Services.Scheduled;
using PromoTik.Domain.Services;
using PromoTik.Domain.Services.Scheduled;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPublishChatMessageRepo, PublishChatMessageRepo>();
builder.Services.AddScoped<IGeneralConfigurationRepo, GeneralConfigurationRepo>();
builder.Services.AddScoped<ILineExecutionRepo, LineExecutionRepo>();
builder.Services.AddScoped<IPublishingChannelRepo, PublishingChannelRepo>();
builder.Services.AddScoped<IPublishChatMessageService, PublishChatMessageService>();
builder.Services.AddScoped<IAppsConnectionControlService, AppsConnectionControlService>();
builder.Services.AddScoped<ILineExecutionService, LineExecutionService>();

builder.Services.AddHostedService<TimedHostedService>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseIISIntegration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PromoTik"));
}

app.UseHttpsRedirection();

app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
