using System;

namespace AppSight.Extensions.System
{
    public static class BytesExtensions
    {
		public static string ToHashString(this byte[] bytes)
		{
			return BitConverter.ToString(bytes).Replace("-", "").ToLower();
		}
	}
}