
using ApplicationApi.Data;
using AutoMapper;
using ApplicationApi.Data.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(c => {
    c.AddProfile<ApplicatonProfile>();
});
builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

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

