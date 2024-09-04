using SoapCore;
using SOPSService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHelperService, HelperService>();
builder.Services.AddSoapCore();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSoapEndpoint<IHelperService>("/SoapService.asmx", new SoapEncoderOptions());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Urls.Add(Constants.SoapServiceUrl);

app.Run();
