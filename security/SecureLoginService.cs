using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Forza HTTPS
app.UseHttpsRedirection();
app.UseHsts();

app.Run();

// Abilita 2FA
var user = await _userManager.FindByNameAsync(username);
var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

// Invia token via email
await _emailService.SendAsync(user.Email, "Codice 2FA", $"Il tuo codice è: {token}");

// Verifica token
var isValid = await _userManager.VerifyTwoFactorTokenAsync(
    user, "Email", userInputToken);