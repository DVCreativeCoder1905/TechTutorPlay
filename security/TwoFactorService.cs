using Microsoft.AspNetCore.Identity;
using OtpNet;
using QRCoder;

public class ApplicationUser : IdentityUser
{
    public string? TwoFactorSecretKey { get; set; }
}

public class TwoFactorService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public TwoFactorService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // Genera chiave segreta per l'utente
    public async Task<string> GenerateSecretKeyAsync(ApplicationUser user)
    {
        var key = KeyGeneration.GenerateRandomKey(20);
        var base32Key = Base32Encoding.ToString(key);
        
        user.TwoFactorSecretKey = base32Key;
        await _userManager.UpdateAsync(user);
        
        return base32Key;
    }

    // Genera QR code per app authenticator
    public byte[] GenerateQrCode(string email, string secretKey, string appName = "TechTutor")
    {
        var qrCodeUri = $"otpauth://totp/{appName}:{email}?secret={secretKey}&issuer={appName}";
        
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(qrCodeUri, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        
        return qrCode.GetGraphic(20);
    }

    // Verifica codice TOTP
    public bool VerifyTotpCode(string secretKey, string userCode)
    {
        var key = Base32Encoding.ToBytes(secretKey);
        var totp = new Totp(key);
        
        return totp.VerifyTotp(userCode, out _, new VerificationWindow(2, 2));
    }
}