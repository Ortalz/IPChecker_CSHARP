using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VirusTotal
{
    public class VirusTotalService : ICheckIPService
    {
        private static readonly HttpClient client = new HttpClient();
        private static int amountOfLoops;
        
        //private static VirusTotalKeys _apiKeys;

        static VirusTotalService()
        {
        }

        public async Task<Ip> CheckIP(Ip IPToCheck)
        {
            try
            {
                amountOfLoops = 0;

                var response = await VirusTotalRequest(IPToCheck.IPAddress);
                var statusCode = response.StatusCode;
                

                const HttpStatusCode _200 = HttpStatusCode.OK;
                const HttpStatusCode _204 = HttpStatusCode.NoContent;
                const HttpStatusCode _404 = HttpStatusCode.NotFound;

                while (statusCode == _204 && amountOfLoops < AmountOfKeys() - 1)
                {
                    amountOfLoops++;
                    NextKey();
                    response = await VirusTotalRequest(IPToCheck.IPAddress);
                    statusCode = response.StatusCode;
                }
                 
                switch(statusCode)
                {
                    case _200:
                        IPToCheck.TimeChecked = new DateTime();
                        IPToCheck.Country = "";
                        IPToCheck.IsChecked = true;
                        var content = await response.Content.ReadAsStringAsync();
                        IPToCheck.IPInfo = FilterInfo(content);
                        IPToCheck.IsMalicious = IsMalicious(content);
                        break;

                    case _204:
                        IPToCheck.IsChecked = false;
                        IPToCheck.IPInfo = "Please try again in 1 minute";
                        break;

                    case _404:
                        IPToCheck.IsChecked = false;
                        IPToCheck.IPInfo = "Something went wrong";
                        break;

                    default:
                        IPToCheck.IsChecked = false;
                        IPToCheck.IPInfo = "Something went wrong";
                        break;
                }

                return IPToCheck;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Problem with returning the checkd ip: ");
                Console.WriteLine(e.Message);

                IPToCheck.IsChecked = false;
                IPToCheck.IPInfo = "Something went wrong";
                return IPToCheck;
            }
        }

        private async Task<HttpResponseMessage> VirusTotalRequest(string ipAddress)
        {
            var url = $"https://www.virustotal.com/vtapi/v2/ip-address/report?apikey={CurrentKey()}&ip={ipAddress}";
            HttpResponseMessage response = await client.GetAsync(url);
            return response;
        }

        private static string CurrentKey()
        {
            return VirusTotalKeys.getCurrentKey();
        }

        private static string NextKey()
        {
            return VirusTotalKeys.getNextKey();
        }

        private static int AmountOfKeys()
        {
            return VirusTotalKeys.getAmountOfKeys();
        }

        private static string FilterInfo(string _rawInfo)
        {
            StringBuilder info = new StringBuilder();
            var data = (JObject)JsonConvert.DeserializeObject(_rawInfo);
            string country = $"Country: { data["country"].Value<string>() }, ";

            var detected_urls = data.GetValue("detected_urls");
            int count_detected_urls;
            if (detected_urls != null)
            {
                count_detected_urls = detected_urls.Count<JToken>();
            }
            else
            {
                count_detected_urls = 0;
            }
            
            string malicious = $"Total Malicious URLS: {count_detected_urls}, ";


            var undetected_urls = data.GetValue("undetected_urls");
            int count_undetected_urls;
            if (undetected_urls != null)
            {
                count_undetected_urls = undetected_urls.Count<JToken>();
            }
            else
            {
                count_undetected_urls = 0;
            }

            string clean_urls = $"Clean URLS: {count_undetected_urls}";

            info.Append(country);
            info.AppendLine();
            info.Append(malicious);
            info.AppendLine();
            info.Append(clean_urls);

            return info.ToString();
        }

        private static string IsMalicious(string _rawInfo)
        {
            var data = (JObject)JsonConvert.DeserializeObject(_rawInfo);
            var detected_urls = data.GetValue("detected_urls");

            if (detected_urls != null && detected_urls.Count<JToken>() > 0)
                return "true";

            return "false";

        }
    }
}
