using System;

namespace Backend.Services.Cupones
{
    public class CuponService
    {
        private static readonly Random random = new Random();
        private const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerateRandomCuponCode(int length = 8)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(result);
        }
    }
}