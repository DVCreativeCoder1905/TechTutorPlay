using Microsoft.AspNetCore.Identity;

// Usa ASP.NET Core Identity
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}

// Startup/Program.cs
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Policy per password forti
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
    
    // Lockout dopo tentativi falliti
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    
    // Richiedi email confermata
    options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();