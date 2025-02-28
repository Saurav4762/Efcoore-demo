using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Repository;
using saurav.Repository.Interface;
using saurav.Service;
using saurav.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


builder.Services.AddDbContext<EfCoreDbcontext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    b.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();