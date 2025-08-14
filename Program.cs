using Microsoft.EntityFrameworkCore;
using TaskForge.Data;
using TaskForge.Services;
using TaskForge.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrace Entity Framework s SQLite databází
builder.Services.AddDbContext<TaskForgeDbContext>(options =>
    options.UseSqlite("Data Source=TaskForge.db"));

// Registrujeme naši službu pro práci s úkoly
builder.Services.AddScoped<IUkolService, UkolService>();

var app = builder.Build();

// vytvoření databáze a tabulek
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskForgeDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
