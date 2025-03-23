using Chinook.Data;                  // 👈 For ChinookContext
using Microsoft.EntityFrameworkCore; // 👈 For UseSqlite extension method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ✅ Add ChinookContext for dependency injection
builder.Services.AddDbContext<ChinookContext>(options =>
    options.UseSqlite("Data Source=chinook.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
