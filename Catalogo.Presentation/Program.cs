using CatalogoApp.Application.Services;
using CatalogoApp.Infrastructure.Repositories;
using CatalogoApp.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Rutas de los archivos JSON
var itemsPath = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");
var usersPath = Path.Combine(builder.Environment.ContentRootPath, "data", "users.json");
var reviewsPath = Path.Combine(builder.Environment.ContentRootPath, "data", "reviews.json");

// Registrar repositorios
builder.Services.AddSingleton<IUserRepository>(new JsonUserRepository(usersPath));
builder.Services.AddSingleton<IReviewRepository>(new JsonReviewRepository(reviewsPath));

// Registrar ItemRepository con dependencia de ReviewRepository
builder.Services.AddSingleton<IItemRepository>(sp =>
{
    var reviewRepo = sp.GetRequiredService<IReviewRepository>();
    return new JsonItemRepository(itemsPath, reviewRepo);
});

// Registrar servicios
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ReviewService>();

// Configurar sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Habilitar sesiones
app.UseSession();

app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

