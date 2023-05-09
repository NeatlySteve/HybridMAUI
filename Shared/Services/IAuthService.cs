using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Services
{
	public interface IAuthService
	{
		bool GetAuthenticated();

		bool GetAuthenticated(string username, string password);

		bool RegisterUser();
		bool RegisterUser(string username, string password);
	}
}

