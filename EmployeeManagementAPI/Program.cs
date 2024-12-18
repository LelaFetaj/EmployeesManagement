using EmployeeManagementAPI.Infrastructures.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddControllerWithFilters();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddAuthenticationContext();
builder.Services.AddManagementContext();
builder.Services.AddAuthenticationBrokers();
builder.Services.AddAuthenticationServices();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerService();
}

app.UseHttpsRedirection();
app.MapControllers(); 


app.Run();

