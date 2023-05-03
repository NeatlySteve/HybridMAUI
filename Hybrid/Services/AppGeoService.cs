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
        public async Task<Position?> GetPosition()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            switch (status)
            {
                case PermissionStatus.Granted:
                case PermissionStatus.Denied:
                    //Nothing
                    break;
                default:
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    break;
            }
            if (status == PermissionStatus.Granted)
            {
                var geoLocal = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var position = await Geolocation.Default.GetLocationAsync(geoLocal);
                return new Position()
                {
                    Latitude = position.Latitude,
                    Longitude = position.Longitude,
                };
            }
            return null;

        }
    }
}
