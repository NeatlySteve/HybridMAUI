using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Numerics;

namespace SharedResources.DB
{
	public class Userbase
	{
		public Userbase(UserAction action, string user, string password)
		{
			
				EncryptedUser inUser = new EncryptedUser(user, password);
				switch (action)
				{
					case UserAction.register:
						if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
						{
							WriteToFile(inUser);
						}
						break;
					case UserAction.login:
						break;
				}
				EncryptedUsers = ReadFromFile();
		}



		public enum UserAction
		{
			register,
			login
		}

		private List<EncryptedUser> GetEncryptedUsers()
		{
			return ReadFromFile();
		}

		const string FileLocation = "C:\\Users\\smillbourn\\source\\repos\\HybridMAUI\\Shared\\DB\\userpass.txt";

		public class EncryptedUser
		{
			public EncryptedUser(string user, string pass)
			{
				this.User = user;
				this.Pass = pass;
			}

			public string User { get; set; }
			public string Pass { get; set; }
		}

		public List<EncryptedUser> EncryptedUsers { get => _encryptedUsers; set => _encryptedUsers = value; }
		private List<EncryptedUser> _encryptedUsers = new List<EncryptedUser>();

		public static void WriteToFile(EncryptedUser encryptedUser, string filePath = FileLocation)
		{
			List<EncryptedUser> temp = ReadFromFile();
			temp.Add(encryptedUser);
			string json = JsonConvert.SerializeObject(temp);
			File.WriteAllText(filePath, json);
		}

		public static List<EncryptedUser> ReadFromFile(string filePath = FileLocation)
		{
			string json = File.ReadAllText(filePath);
			var temp = JsonConvert.DeserializeObject<List<EncryptedUser>>(json);
			List<EncryptedUser> data = (temp != null) ? temp : new List<EncryptedUser>();
			return data;
		}

	}
}
