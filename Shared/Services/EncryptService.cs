using System.Security.Cryptography;
using System.Text;

namespace Web.Services
{
	public class EncryptService
	{
		public static string ComputeSha256Hash(string rawData)
		{
			// Create a new instance of the SHA256 algorithm
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// Convert the input string to a byte array
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Create a StringBuilder to collect the bytes
				StringBuilder builder = new StringBuilder();

				// Loop through each byte in the hashed bytes
				for (int i = 0; i < bytes.Length; i++)
				{
					// Append each byte to the StringBuilder in hexadecimal format
					builder.Append(bytes[i].ToString("x2"));
				}

				// Return the hexadecimal string
				return builder.ToString();
			}
		}
	}
}
