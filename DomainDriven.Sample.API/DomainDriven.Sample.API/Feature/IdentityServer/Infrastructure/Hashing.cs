using System.Security.Cryptography;
using System.Text;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Infrastructure
{
    public class Hashing
    {
        public static byte[] Hash(string hashingData)
        {
            byte[] secretKey;
            using (SHA256 sha = SHA256.Create())
            {
                secretKey = sha.ComputeHash(Encoding.UTF8.GetBytes(hashingData));

            }
            return secretKey;
        }
    }
}
