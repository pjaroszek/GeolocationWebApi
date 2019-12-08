namespace GeolocationWebApi.Models
{/// <summary>
/// Geolocalization details
/// </summary>
    public class GeoLocalization
    {
        public int id { get; set; }
        /// <summary>
        /// IP Adress
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// URL Adress
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// Region name
        /// </summary>
        public string region { get; set; }
        //country code
        public string country { get; set; }
        /// <summary>
        /// geographic localization
        /// </summary>
        public string loc { get; set; }
        /// <summary>
        /// Organmization, company name
        /// </summary>
        public string org { get; set; }
        /// <summary>
        /// Postal code
        /// </summary>
        public string postal { get; set; }
        /// <summary>
        /// Time zone
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// description - readme
        /// </summary>
        public string readme { get; set; }
    }
}