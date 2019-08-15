using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace IpsScraper
{
    class Program
    {
        private static readonly string _textFilePath = @"..\..\..\IPs\ips.txt";
        private static readonly string _jsonFilePath = @"..\..\..\Data\ips.json";


        static async Task Main(string[] args)
        {
            var isBuild = await BuildJson();
            if(isBuild)
                Console.WriteLine("Json file build successfully");
            else
                Console.WriteLine("Json file build failed");
        }

        private static async Task<bool> BuildJson()
        {
            List<Ip> _ips = new List<Ip>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(_textFilePath))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = await sr.ReadToEndAsync();
                    string[] ips = line.Split(',');

                    foreach (var ip in ips)
                    {
                        _ips.Add(BuildIP(ip));
                    }

                    return ConvertListToJsonAndSave(_ips);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file {_textFilePath} could not be read: ");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static Ip BuildIP(string ipAddress)
        {
            return new Ip() { IPAddress = ipAddress }; ;
        }

        private static bool ConvertListToJsonAndSave(List<Ip> ips)
        {
            var jsonIPS = JsonConvert.SerializeObject(ips);
            try
            {
                File.WriteAllText(_jsonFilePath, jsonIPS);
                Console.WriteLine($"The file {_jsonFilePath} was written");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file {_jsonFilePath} could not be written:");
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

        


    