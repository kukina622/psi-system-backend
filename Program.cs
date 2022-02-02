using Microsoft.EntityFrameworkCore;
using psi.context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
  options.AddDefaultPolicy(builder => {
    builder.WithOrigins("http://localhost:8000")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
  });
});

// register context
builder.Services.AddDbContext<inventoryContext>(options =>
  options.UseMySQL(builder.Configuration.GetConnectionString("MySQL")
));
builder.Services.AddDbContext<userContext>(options =>
  options.UseMySQL(builder.Configuration.GetConnectionString("MySQL")
));
builder.Services.AddDbContext<customerContext>(options =>
  options.UseMySQL(builder.Configuration.GetConnectionString("MySQL")
));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.UseCors();

// register endpoint/route
app.MapCustomerEndpoints();
app.MapInventoryEndpoints();

app.Run("http://localhost:3000");
