/*
 * C# MetOffice Weather Observation Website API Client
 * http://github.com/networkfusion/metoffice-wow
 * Copyright (C) 2021 Robin Jones

 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Diagnostics;
using System.Net;
using MetOffice.WoW.ApiSchema;
using nanoFramework.Json;

namespace MetOffice.WoW
{
    /// <summary>
    /// HTTP Sender for the MetOffice Weather Observations Website API.
    /// </summary>
    /// <remarks>
    /// Further information for V1 (depricated) can be found at https://wow.metoffice.gov.uk/support/dataformats
    /// Further information for V2 can be found at https://mowowprod.portal.azure-api.net/documentation/how-to-connect-to-wow-api
    /// </remarks>
    public static class HttpSender
    {
        private static DateTime lastSendTimestamp = DateTime.UtcNow.Subtract(new TimeSpan(0, 5, 0 )); //Subtract 5 minutes to ensure (default) send on creation. - TODO: could be improved!

        public static int SendData(string data, ConnectionInformationV1 connectionInfo, ApiSchema.ApiSchemaVersion apiSchemaVersion = ApiSchema.ApiSchemaVersion.VersionOne)
        {
            if (lastSendTimestamp >= DateTime.UtcNow) //TODO: should be ignored if  last send was unsucessful!
            {
                var httpStatusCode = 401; // unauthorised as default.

                //check that the send interval is greater than the minimum or wait
                //if (connectionInfo.SendInterval > lastSendTimestamp)

                switch (apiSchemaVersion)
                {
                    case ApiSchema.ApiSchemaVersion.VersionOne:
                        httpStatusCode = HandleV1ObservationData(data, connectionInfo); //TODO: should we have converted it to a string yet?
                        break;
                    case ApiSchema.ApiSchemaVersion.VersionTwo:
                        throw new Exception("API version in development.");
                    default:
                        throw new Exception("API version unsupported.");
                }


                lastSendTimestamp = DateTime.UtcNow;

                return httpStatusCode;
            }
            else
            {
                throw new Exception("Minimum time interval not met");
            }
        }


        /// <summary>
        /// Sends an observation compatible with the V1 API format.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int HandleV1ObservationData(string data, ConnectionInformationV1 connectionInfo)
        {
            // http://wow.metoffice.gov.uk/automaticreading?siteid=123456&siteAuthenticationKey=654321&dateutc=2011-02-02+10%3A32%3A55&winddir=230&windspeedmph=12&windgustmph=12&windgustdir=25&humidity=90&dewptf=68.2&tempf=70&rainin=0&dailyrainin=5&baromin=29.1&soiltempf=25&soilmoisture=25&visibility=25&softwaretype=weathersoftware1.0
            var url = $" { connectionInfo.Url } /automaticreading?" +
                 $"siteid= { connectionInfo.SiteId } " +
                 $"&siteAuthenticationKey= { connectionInfo.SiteApiAuthenticationKey } " +
                 $"&dateutc= { DateTime.UtcNow } " + //This might not be correct if reading from a datasource, but it will do for an example. (as long as it id encoded as ISO8601... YYYY-mm-DD HH:mm:ss ...URI encoded)
                 $"&softwaretype= {connectionInfo.Softwaretype} ";

            Debug.WriteLine(url); //Should be trace!

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            // set the headers we are going to pass a json body so use a content type of Json
            //httpWebRequest.ContentType = "application/json";
            // Use TLS 1.2.
            //httpWebRequest.SslProtocols = System.Net.Security.SslProtocols.Tls12;

            // Now we need to add the actual sensor data.
            var sensorData = (VersionOne)JsonConvert.DeserializeObject(data, typeof(VersionOne));
            //We need to itterate through each item in the class as a key and value pair.
            //foreach (var item in sensorData) //being property of the class...
            //{
            //    if (!string.IsNullOrEmpty(item))
            //        url += $"${$item}";
            //}

            //need to validate the schema parameters?!


            //send (urlencode, and record time)
            //using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            //{
            //    return httpWebResponse;
            //}

            //Check for http status code 200 (for sucessful upload)
            return 401; // unauthorised as default.

        }


        /// <summary>
        /// Sends an observation compatible with the V2 API format.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://mowowprod.portal.azure-api.net/documentation/how-to-connect-to-wow-api
        /// </remarks>
        private static int HandleV2ObservationData(string data, ConnectionInformationV1 connectionInfo) //this needs to target v2!
        {
            using (var httpWebRequest = (HttpWebRequest)WebRequest.Create(connectionInfo.Url))
            {
                ////httpClient.BaseAddress = new Uri("https://mowowprod.azure-api.net");
                //httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                //var observation = new
                //{
                //    SiteId = "a27e78e7-2b39-e611-9cd2-28d244e1ce6c",
                //    SiteAuthenticationKey = "123123",
                //    ReportEndDateTime = DateTime.Now,
                //    DryBulbTemperature_Celsius = 12
                //};

                //using (var response = httpClient.Post("/api/observations", new StringContent(JsonConvert.SerializeObject(observation), Encoding.UTF8, "application/json")))
                //{
                //    response.EnsureSuccessStatusCode();
                //    return JObject.Parse(response.Content.ReadAsStringAsync());
                //}
                return 401;
            }
        }
    }
}
