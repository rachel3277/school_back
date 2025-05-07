using Bl;
using Bl.Api;
using Bl.Models;
using Bl.Services;

var builder = WebApplication.CreateBuilder(args);

//�� �� ������� ��� ������ �������

builder.Services.AddSingleton<IBl, BlManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//.AllowAnyMethod()  ������ ��� ����� ���� �� ��������� ����� ���
builder.Services.AddCors(c => c.AddPolicy("AllowAll",
    option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader().AllowAnyMethod()));


var app = builder.Build();

//������ ���� ����� � app
app.UseCors("AllowAll");


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
