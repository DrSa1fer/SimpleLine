using Microsoft.Extensions.DependencyInjection;
using simpleline;

var builder = new SimpleLineBuilder();

builder.Services.AddScoped<object>();
builder.Services.AddScoped<object>();
builder.Services.AddScoped<object>();
builder.Services.AddScoped<object>();
builder.Services.AddScoped<object>();
builder.Services.AddScoped<object>();

var simpleline = builder.Build();

simpleline.Run([ "1", "-l", "9", "-r", "1000"]);