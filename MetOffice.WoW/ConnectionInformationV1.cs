using System;

namespace MetOffice.WoW
{
    public class ConnectionInformationV1
    {
        /// <summary>
        /// Minimum send interval for the API
        /// </summary>
        /// <remarks>
        /// In Minutes
        /// </remarks>
        public const int MinimumSendInterval = 5;

        /// <summary>
        /// The send interval for the API
        /// </summary>
        /// <remarks>
        /// In Minutes
        /// </remarks>
        public int SendInterval { get; set; } = MinimumSendInterval;

        /// <summary>
        /// Default URL
        /// </summary>
        /// <remarks>
        /// The Met Office.
        /// </remarks>
        public string Url { get; set; } = "http://wow.metoffice.gov.uk/automaticreading";
        /// <summary>
        /// The Weather Observation Site ID
        /// </summary>
        public string SiteId { get; set; }// = "TEST";
        /// <summary>
        /// The Weather Observation Site API Authentication kay
        /// </summary>
        public string SiteApiAuthenticationKey { get; set; }
        /// <summary>
        /// API version?!
        /// </summary>
        public string Softwaretype = "weathersoftware1.0"; //TODO: is this actually the API version?!
    }
}
