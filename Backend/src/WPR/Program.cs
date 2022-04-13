using WPR.Core;
using WPR.Data;
using WPR.Swagger;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCore();
builder.Services.AddData(builder.Configuration);

if (builder.Environment.IsDevelopment()) builder.Services.AddSwaggerGen(SwaggerConfiguration.SetUp);

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