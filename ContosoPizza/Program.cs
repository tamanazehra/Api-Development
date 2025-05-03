var builder = WebApplication.CreateBuilder(args);

//  Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- Swagger services

var app = builder.Build();

//  Enable Swagger middleware globally
app.UseSwagger();           // Generate Swagger JSON
app.UseSwaggerUI();         // Show Swagger UI in browser

//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();


