using DataLayer;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Context
    builder.Services.AddDbContext<DataContext>();

    // Firebase
    builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromJson(builder.Configuration.GetValue<string>("FirebaseConfig"))
    }));

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
        opt.Authority = builder.Configuration.GetValue<string>("Jwt:Firebase:ValidIssuer");

        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Firebase:ValidIssuer"),
            ValidAudience = builder.Configuration.GetValue<string>("Jwt:Firebase:ValidAudience")
        };
    });

    // Custom Services
    builder.Services.AddScoped<IFAQService, FAQService>();
};

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication(); // Will set HTTPConext.User (ClaimsPrinciple)
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
