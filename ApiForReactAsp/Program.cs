using ApiForReactAsp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://example.com",
//                                              "http://www.contoso.com");
//                      });
//});

 void ConfigureServices(IServiceCollection services)


{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });
}

 void Configure(IApplicationBuilder app)
{
    app.UseCors("AllowAll");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
app.UseCors(builder => builder.WithOrigins("http://domain.com")); // Allow requests only from domain.com
app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request
//app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();



app.MapControllers();

app.Run();
