namespace GeolocationWebApi.Interfaces
{
    using GeolocationWebApi.Models;

    public interface IIpInfoServices
    {
        GeoLocalization GetDataIpInfo(string url);
    }
}