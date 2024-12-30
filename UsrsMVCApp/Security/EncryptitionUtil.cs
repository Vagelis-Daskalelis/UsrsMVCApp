namespace UsrsMVCApp.Security
{
    public static class EncryptitionUtil
    {
        public static string Encrypt(string clearText)
        {
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(clearText);
            return encryptedPassword;
        }

        public static bool IsValidPassword(string clearText, string cipherText) 
        {
            var isValid = BCrypt.Net.BCrypt.Verify(clearText, cipherText);
            return isValid;
        }
    }
}
