using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Andronic_Paul_Proiect.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Andronic_Paul_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Andronic_Paul_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Andronic_Paul_ProiectContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
