using BankBusiness.Interfaces;
using BankBusiness.Manager;
using BankData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(policyBuilder =>
policyBuilder.AddDefaultPolicy(policy =>
policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

builder.Services.AddScoped<IClientManager, ClientManager>();
builder.Services.AddScoped<IFinantialProductManager, FinantialProductManager>();
builder.Services.AddScoped<ILegalRepresentativeManager, LegalRepresentativeManager>();
builder.Services.AddScoped<ICountryManager, CountryManager>();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
