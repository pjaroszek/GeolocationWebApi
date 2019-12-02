using GeolocationWebApi.Models;

namespace Jaroszek.ProofOfConcept.GeolocationWebApi.Interfaces
{
    public interface IIpInfoServices
    {
        GeoLocalization GetDataIpInfo(string url);
    }
}