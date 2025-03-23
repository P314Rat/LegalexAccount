using System.Security.Cryptography;
using System.Text;


namespace Utilities.StaticServices
{
    public static class GenerateDataService
    {
        public static string GenerateInitialPassword(int length)
        {
            var password = "";
            var symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            var random = new Random();

            for (var i = 0; i < length; i++)
            {
                var index = random.Next(symbols.Length);
                password += symbols[index];
            }

            return password;
        }

        public static string GenerateHash(string input, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

                return Convert.ToBase64String(hash);
            }
        }

        public static string GenerateSalt(int size)
        {
            var rng = RandomNumberGenerator.Create();
            var buffer = new byte[size];

            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
    }
}
