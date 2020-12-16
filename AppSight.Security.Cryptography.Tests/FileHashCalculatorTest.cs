using AppSight.System.Extensions;
using AppSight.Security.Cryptography;
using Xunit;

namespace AppSight.FileHashChecker.Library.Tests
{
    public class FileHashCalculatorTest
    {
        [Fact]
        public void TestCalculateAsciiFile()
        {
            var calculator = new FileHashCalculator();
            var filePathInput = "tux.txt";
            var hashTypeInputs = new[]
            {
                HashType.MD5,
                HashType.SHA1,
                HashType.SHA256,
                HashType.SHA512,
            };
            var expectedHasheStrings = new[]
            {
                "5ab6e4b98bc7fb716fc07ed98fedf802",
                "2970eb1fef549b6a4039e7fd2336ba16b18bcbd2",
                "ec2dc675422c8eeb1eef26e7c67c3d74713e947bda7378896d8e3cf4dc5f0161",
                "b6e7a9b249cdfecdd037c1615dbfdfa35cd0e54e08cd27ed88fceb97296dfa1c512ecf636364f0c9ed6a49cee3574ea91327efc5969bd918175441777e8bc07f",
            };

            for (var i = 0; i < hashTypeInputs.Length; i++)
            {
                var hashTypeInput = hashTypeInputs[i];
                var actualHash = calculator.Calculate(filePathInput, hashTypeInput);
                var expectedHashString = expectedHasheStrings[i];
                Assert.Equal(expectedHashString, actualHash.ComputedHash.ToHashString());
            }
        }

        [Fact]
        public void TestCalculateBinaryFile()
        {
            var calculator = new FileHashCalculator();
            var filePathInput = "tux.png";
            var hashTypeInputs = new[]
            {
                HashType.MD5,
                HashType.SHA1,
                HashType.SHA256,
                HashType.SHA512,
            };
            var expectedHasheStrings = new[]
            {
                "bede490bfe83a2847e1503b3eb5085c7",
                "be598b6d3e3f4f4232abbdc1e90ff900a0c3ccd2",
                "8fc6897c39e60c0d246d992c9b7057ac483f37a7b0d85b69bdc42c652e9a60ee",
                "7b9f4e15ee56cdcf075a736ffb2766e44573601fbbdc485a9bf4a710ee49b41d5c57367ebbf9caecf995404e2f14e98a61986488a0981433ea228d60c86a5a09",
            };

            for (var i = 0; i < hashTypeInputs.Length; i++)
            {
                var hashTypeInput = hashTypeInputs[i];
                var actualHash = calculator.Calculate(filePathInput, hashTypeInput);
                var expectedHashString = expectedHasheStrings[i];
                Assert.Equal(expectedHashString, actualHash.ComputedHash.ToHashString());
            }
        }
    }
}
