
using Lab8.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
//generate swagger xml
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "LizaX", Version = "v1" });
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Lab8.xml"));
});
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSwagger();

app.MapGet("/", (IUserRepository userRepository) => userRepository.Get()).WithTags("Liza");
app.MapGet("/{id}", (int id, IUserRepository userRepository) => userRepository.GetSingle(id)).WithTags("Liza");

app.MapPost("/create", async (User user, IUserRepository userRepository) => 
    await userRepository.CreateAsync(user) ? "Created" : "check data").WithTags("Liza");

app.MapPut("/update", async (User user, IUserRepository userRepository) => 
    await userRepository.UpdateItemAsync(user) ? "Updated" : "check data").WithTags("Liza");

app.MapDelete("/delete/{id}", async (int id, IUserRepository userRepository) => 
    await userRepository.DeleteAsync((b) => b.Id == id) ? "Deleted" : "check data").WithTags("Liza");

app.UseSwaggerUI();
app.Run();