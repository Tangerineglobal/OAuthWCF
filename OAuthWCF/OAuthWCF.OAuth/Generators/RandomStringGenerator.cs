using System;
using System.Security.Cryptography;

namespace OAuthWCF.OAuth.Generators {
    internal class RandomStringGenerator {
        public static string GetRandomString(int size) {
            using (RandomNumberGenerator cryptoServiceProvider = new RNGCryptoServiceProvider()) {
                byte[] numArray = new byte[size];
                cryptoServiceProvider.GetBytes(numArray);

                string token = Convert.ToBase64String(numArray);

                return token;
            }
        }
    }
}
