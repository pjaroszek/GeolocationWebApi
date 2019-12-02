﻿namespace GeolocationWebApi.Models
{
    public class GeoLocalization
    {
        public int id { get; set; }
        public string ip { get; set; }
        public string url { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
        public string readme { get; set; }
    }
}