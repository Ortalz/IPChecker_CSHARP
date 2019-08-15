using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace DataManager
{
    /**
     * The class is uniqe to a specific DB.
     * It has its own configuration that is relevent to this class only.
     * This class is created only once. (static / singleton)
     */
    public class DataManagerService : IDataManagerService
    {
        private static readonly string _jsonFilePath = @"..\..\..\Data\ips.json";
        private static ReaderWriterLock readerWriterLock = new ReaderWriterLock();
        private static MongoConnetion _mongoConnetion = MongoConnetion.GetInstance();
        private static List<Ip> _ips;

        static DataManagerService()
        {
            buildLocalData();
        }

        public void AddIp(Ip ip)
        {
            
        }

        private static void buildLocalData()
        {
            try
            {
                readerWriterLock.AcquireReaderLock(int.MaxValue);
                _ips = JsonConvert.DeserializeObject<List<Ip>>(File.ReadAllText(_jsonFilePath));
            }
            catch(Exception e)
            {
                Console.WriteLine($"The file {_jsonFilePath} could not be deserialized: ");
                Console.WriteLine(e.Message);
                _ips = new List<Ip>();
            }
            finally
            {
                readerWriterLock.ReleaseReaderLock();
            }
            
        }

        public void AddIps(List<Ip> ips)
        {

        }

        public async Task<List<Ip>> GetIPs()
        {
            return _ips;
        }


        public void ReplaceIpInfo(Ip newIp)
        {
            _ips[_ips.FindIndex(ip=>ip.IPAddress == newIp.IPAddress)] = newIp;
        }
    }
}
