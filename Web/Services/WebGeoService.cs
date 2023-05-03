using SharedResources.Services;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.JSInterop;

namespace Web.Services
{
	public class WebGeoService : IGeoService
	{
		private readonly IJSRuntime jSRuntime;
		public WebGeoService(IJSRuntime jSRuntime)
		{
			this.jSRuntime = jSRuntime;
		}

		public async Task<Position?> GetPosition()
		{
			var service = new GeolocationService(jSRuntime);
			var result = await service.GetCurrentPosition();

			return new Position()
			{
				Latitude = result.Position.Coords.Latitude,
				Longitude = result.Position.Coords.Longitude
			};
		}
	}
}
