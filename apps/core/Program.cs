global using AudioStreaming.Models;
global using AudioStreaming.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
  {
    BearerFormat = "JWT",
    Scheme = "bearer",
    Description = "Specify the authorization token.",
    Type = SecuritySchemeType.Http,
  };

  options.AddSecurityDefinition("Bearer", securityDefinition);

  OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        },
        new string[] {}
    }
};

  options.AddSecurityRequirement(securityRequirements);
});

// Add data contexts
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<IdentityContext>();

// Setup Core Identity integration
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<IdentityContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = configuration["JWT:ValidAudience"],
    ValidIssuer = configuration["JWT:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
  };
});

var app = builder.Build();

// Seed
using (var scope = app.Services.CreateScope())
{
  scope.ServiceProvider.GetRequiredService<DataContext>().Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
