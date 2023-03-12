using CanfieldSchool.Database_context;
using CanfieldSchool.SchoolRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddDbContext<RegisterDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddTransient<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddTransient<ICanfielSchool, CanfieldSchoolRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CanfieldDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = Configuration["Jwt: Issuer"],
//            ValidAudience = Configuration["Jwt: Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt: Key"]))
//        };
//   });





builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:44354/",
            ValidAudience = "https://localhost:44354/",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });






var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
