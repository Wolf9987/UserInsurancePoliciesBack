using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersInsurancePolicies;
using UsersInsurancePolicies.Data;
using UsersInsurancePolicies.Repositories;
using UsersInsurancePolicies.Repositories.IRepository;

var builder = WebApplication.CreateBuilder(args);
var _loginOrigin = "_localOrigin";

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(_loginOrigin, builder =>
    {
        //builder.WithOrigins("http://localhost:4200");
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();

    });
});

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_loginOrigin);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
