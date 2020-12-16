using System;
using System.IO;
using System.Security.Cryptography;

namespace AppSight.System.Security.Cryptography
{
    public class FileHashCalculator
    {
        public FileHash Calculate(string filePath, HashType hashType)
        {
            if (string.IsNullOrEmpty(filePath)) { throw new ArgumentException(nameof(filePath)); }

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] hashBytes;

                switch (hashType)
                {
                    case HashType.MD5:
                        hashBytes = MD5.Create().ComputeHash(fileStream);
                        break;

                    case HashType.SHA1:
                        hashBytes = SHA1.Create().ComputeHash(fileStream);
                        break;

                    case HashType.SHA256:
                        hashBytes = SHA256.Create().ComputeHash(fileStream);
                        break;

                    case HashType.SHA512:
                        hashBytes = SHA512.Create().ComputeHash(fileStream);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(hashType));
                }

                return new FileHash
                {
                    HashType = hashType,
                    ComputedHash = hashBytes,
                    Path = filePath,
                };
            }
        }
    }
}