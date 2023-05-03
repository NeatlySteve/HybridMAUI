using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Services;

namespace Hybrid.Services
{
	public class AppGeoService : IGeoService
	{
		public AppGeoService() { }
		public async Task<Position> GetPosition()
		{
			var position = await Geolocation.Default.GetLocationAsync();

			return new Position()
			{
				Latitude = position.Latitude,
				Longitude = position.Longitude,
			};
		}
	}
}
