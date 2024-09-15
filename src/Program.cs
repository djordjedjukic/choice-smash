using ChoiceSmash.Infrastructure;
using ChoiceSmash.Services;
using FluentValidation;
using MediatR;
using Refit;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// my preference is to use ravendb (or seq) as sink for logging, but it is overkill for this case
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Scoreboard>();
builder.Services.AddTransient<RandomService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

builder.Services
    .AddRefitClient<IRandomApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://codechallenge.boohma.com"));

builder.Services.Scan(
    x =>
    {
        x.FromAssemblies(typeof(Program).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(AbstractValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime();
    });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// added this so I can test it against codechallenge.boohma.com using Ngrok
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.Run();