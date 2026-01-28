using System.Runtime.InteropServices;
using System.Security;

public class SecureCredentialHandler
{
    public bool ValidateCredentials(SecureString securePassword)
    {
        IntPtr ptr = IntPtr.Zero;
        try
        {
            ptr = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
            string password = Marshal.PtrToStringUni(ptr);
            
            // Valida la password
            return ValidatePassword(password);
        }
        finally
        {
            // Pulisci la memoria
            if (ptr != IntPtr.Zero)
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
        }
    }
}