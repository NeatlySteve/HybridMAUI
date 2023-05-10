using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Services
{
	public interface IFileService
	{
		Task<Stream> PickFileAsync();
	}
}
