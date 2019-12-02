using GeolocationWebApi.Models;
using Jaroszek.ProofOfConcept.GeolocationWebApi.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Jaroszek.ProofOfConcept.GeolocationWebApi.Services
{
    public class IpInfoServices : IIpInfoServices
    {
        private readonly string SERVICE_ADRESS = Properties.Settings.Default.ServiceAddress;
        private readonly string KEY_TO_SERVICE = Properties.Settings.Default.KeyToService;
        private string urlIpInfo;


        public GeoLocalization GetDataIpInfo(string url)
        {
            IPHostEntry hosts = Dns.GetHostEntry(url);
            var ipFromUrl = hosts.AddressList[0].ToString();

            if (!string.IsNullOrEmpty(KEY_TO_SERVICE))
            {
                urlIpInfo = SERVICE_ADRESS + ipFromUrl + $"?access_key={KEY_TO_SERVICE}";
            }
            else
            {
                urlIpInfo = SERVICE_ADRESS + ipFromUrl;
            }

            var request = System.Net.WebRequest.Create(urlIpInfo);
            using (WebResponse wrs = request.GetResponse())
            using (Stream stream = wrs.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<GeoLocalization>(json);
                result.url = url;
                return result;
            }

            return null;
        }
    }
}