using CanfieldSchool.Database_context;
using CanfieldSchool.SchoolRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddDbContext<RegisterDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddTransient<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddScoped<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddTransient<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CanfieldDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
