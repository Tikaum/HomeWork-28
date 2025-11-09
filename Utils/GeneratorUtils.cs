namespace Wrappers.Utils
{
    public class GeneratorUtils
    {
        public string RandomEmail(int length = 8)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            string email = $"{new string(result)}@gmail.com";
            return email;
        }

        public string RandomPass(int length = 6)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[]  lettersA = new char[length];
            for (int i = 0; i < length; i++)
            {
                lettersA[i] = chars[random.Next(chars.Length)];
            }
            
            const string chars1 = "abcdefghijklmnopqrstuvwxyz";
            char[] lettersB = new char[length];
            for (int i = 0; i < length; i++)
            {
                lettersB[i] = chars[random.Next(chars1.Length)];
            }

            const string chars2 = "!@#?$*%^&0123456789";
            char[] symbols = new char[length];
            for (int i = 0; i < length; i++)
            {
                symbols[i] = chars2[random.Next(chars2.Length)];
            }
            string pass = new string(lettersA)  + new string(lettersA)  + new string(symbols);

            return pass;
        }
    }
}
