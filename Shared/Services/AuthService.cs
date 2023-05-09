using SharedResources.DB;
using SharedResources.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using static SharedResources.DB.Userbase;

namespace SharedResources.Services
{
	public class AuthService : IAuthService
	{
		public bool GetAuthenticated()
		{
			return false;
		}

		public bool GetAuthenticated(string user, string pass)
		{
			string hash = ComputeSha256Hash(pass);
			Userbase newBase = new(UserAction.login, user, hash);
			
			return LoginUser(user, hash, newBase);
		}

		public bool RegisterUser()
		{
			return false;
		}

		public bool RegisterUser(string user, string password)
		{
			string hash = ComputeSha256Hash(password);
			Userbase newBase = new(UserAction.register, user, hash);
			return LoginUser(user, hash, newBase);
		}

		public bool LoginUser(string user, string hash, Userbase newbase)
		{
			return (newbase.EncryptedUsers.Where(u => u.User == user && u.Pass == hash).Count() > 0);
		}
		

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
