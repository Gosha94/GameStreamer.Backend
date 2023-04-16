using System.Text;
using System.Security.Cryptography;
using GameStreamer.Domain.InternalProviders;

namespace GameStreamer.Infrastructure.InternalProviders;

public class HashService : IHashService
{
    public Guid CalculateHashCodeFrom(string value)
    {
        MD5 md5Hasher = MD5.Create();

        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        return new Guid(data);
    }
}
