namespace AppSight.System.Security.Cryptography
{
    public class FileHash
    {
        public HashType HashType { get; set; }
        public byte[] ComputedHash { get; set; }
        public string Path { get; set; }
    }
}